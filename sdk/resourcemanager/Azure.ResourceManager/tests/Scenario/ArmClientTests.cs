﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    class ArmClientTests : ResourceManagerTestBase
    {
        class ProviderCounterPolicy : HttpPipelineSynchronousPolicy
        {
            //"https://management.azure.com/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute?api-version=2019-10-01"
            private ConcurrentDictionary<string, int> counter = new ConcurrentDictionary<string, int>();
            private Regex _resourceGroupPattern = new Regex(@"/subscriptions/[^/]+/providers/([^?/]+)\?api-version");

            public int GetCount(string nameSpace)
            {
                return counter.TryGetValue(nameSpace, out var count) ? count : 0;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                if (message.Request.Method == RequestMethod.Get)
                {
                    var match = _resourceGroupPattern.Match(message.Request.Uri.ToString());
                    if (match.Success)
                    {
                        var nameSpace = match.Groups[1].Value;
                        if (!counter.TryGetValue(nameSpace, out var current))
                        {
                            counter.TryAdd(nameSpace, 1);
                        }
                        else
                        {
                            counter[nameSpace] = current + 1;
                        }
                    }
                }
            }
        }

        class ResourceGroupVersionTracker : HttpPipelineSynchronousPolicy
        {
            //"https://management.azure.com/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute?api-version=2019-10-01"
            private Regex _resourceGroupPattern = new Regex(@"/resourcegroups/.*\?api-version=(\d\d\d\d-\d\d-\d\d)");

            public string VersionUsed { get; private set; }

            public override void OnSendingRequest(HttpMessage message)
            {
                var match = _resourceGroupPattern.Match(message.Request.Uri.ToString());
                if (match.Success)
                {
                    VersionUsed = match.Groups[1].Value;
                }
            }
        }

        private string _rgName;
        private readonly string _location = "southcentralus";

        public ArmClientTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            Subscription subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            var op = InstrumentOperation(rgCollection.CreateOrUpdate(false, _rgName, new ResourceGroupData(_location)));
            op.WaitForCompletion();
            await StopSessionRecordingAsync();
        }

        [RecordedTest]
        public async Task VerifyDefaultEnumVersionUsed()
        {
            ResourceGroupVersionTracker tracker = new ResourceGroupVersionTracker();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(tracker, HttpPipelinePosition.PerCall);
            var client = GetArmClient(options);
            var subscription = await client.GetDefaultSubscriptionAsync();
            var rgCollection = subscription.GetResourceGroups();
            _ = await rgCollection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS));

            Assert.AreEqual(GetDefaultResourceGroupVersion(rgCollection), tracker.VersionUsed);
        }

        private static string GetDefaultResourceGroupVersion(ResourceGroupCollection rgCollection)
        {
            var restClient = rgCollection.GetType().GetField("_resourceGroupRestClient", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rgCollection) as ResourceGroupsRestOperations;
            return restClient.GetType().GetField("apiVersion", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(restClient) as string;
        }

        [RecordedTest]
        public async Task VerifyOverrideEnumVersionUsed()
        {
            ResourceGroupVersionTracker tracker1 = new ResourceGroupVersionTracker();
            ResourceGroupVersionTracker tracker2 = new ResourceGroupVersionTracker();
            ArmClientOptions options1 = new ArmClientOptions();
            string versionOverride = "2021-01-01";
            options1.SetApiVersion(ResourceGroup.ResourceType, versionOverride);
            ArmClientOptions options2 = new ArmClientOptions();
            options1.AddPolicy(tracker1, HttpPipelinePosition.PerCall);
            options2.AddPolicy(tracker2, HttpPipelinePosition.PerCall);
            var client1 = GetArmClient(options1);
            var client2 = GetArmClient(options2);
            var subscription1 = await client1.GetDefaultSubscriptionAsync();
            var subscription2 = await client2.GetDefaultSubscriptionAsync();
            var rgCollection1 = subscription1.GetResourceGroups();
            var rgCollection2 = subscription2.GetResourceGroups();
            _ = await rgCollection1.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS));
            _ = await rgCollection2.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS));

            Assert.AreEqual(versionOverride, tracker1.VersionUsed);
            Assert.AreEqual(GetDefaultResourceGroupVersion(rgCollection2), tracker2.VersionUsed);
        }

        [RecordedTest]
        public async Task GetUsedResourceApiVersion()
        {
            ProviderCounterPolicy policy = new ProviderCounterPolicy();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            var client = GetArmClient(options);
            var subscription = await client.GetDefaultSubscriptionAsync();
            var version = await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Compute/virtualMachines"));
            Assert.NotNull(version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));

            version = await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Compute/availabilitySets"));
            Assert.NotNull(version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));
        }

        [RecordedTest]
        public async Task GetUsedResourceApiVersionWithOverride()
        {
            ProviderCounterPolicy policy = new ProviderCounterPolicy();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);

            string expectedVersion = "myVersion";
            var computeResourceType = new ResourceType("Microsoft.Compute/virtualMachines");
            options.SetApiVersion(computeResourceType, expectedVersion);

            var client = GetArmClient(options);
            var subscription = await client.GetDefaultSubscriptionAsync();
            var version = await subscription.GetProviders().TryGetApiVersionAsync(computeResourceType);
            Assert.AreEqual(expectedVersion, version);
            Assert.AreEqual(0, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));

            policy = new ProviderCounterPolicy();
            options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);

            client = GetArmClient(options);
            subscription = await client.GetDefaultSubscriptionAsync();
            version = await subscription.GetProviders().TryGetApiVersionAsync(computeResourceType);
            Assert.AreNotEqual(expectedVersion, version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));
        }

        [RecordedTest]
        public void GetUsedResourceApiVersionInvalidResource()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                var subscription = await Client.GetDefaultSubscriptionAsync();
                await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Compute/fakeStuff"));
            });
        }

        [RecordedTest]
        public void GetUsedResourceApiVersionInvalidNamespace()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var subscription = await Client.GetDefaultSubscriptionAsync();
                await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Fake/fakeStuff"));
            });
        }

        [RecordedTest]
        [SyncOnly]
        public void ConstructWithInvalidSubscription()
        {
            var client = GetArmClient(subscriptionId: Recording.Random.NewGuid().ToString());
            var ex = Assert.Throws<RequestFailedException>(() => client.GetDefaultSubscription());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public void TestArmClientParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(default(TokenCredential)); });
            Assert.DoesNotThrow(() => { new ArmClient(TestEnvironment.Credential, default(string)); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(TestEnvironment.Credential, TestEnvironment.SubscriptionId, default(Uri)); });
        }

        [RecordedTest]
        public void GetGenericResourcesOperationsTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/providers/Microsoft.Compute/virtualMachines/myVm";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.ToString());
        }

        [RecordedTest]
        public void GetGenericResourceOperationsSingleIDTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.ToString());
        }

        [RecordedTest]
        public async Task GetGenericResourceOperationsWithSingleValidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(id));
            var genericResource = await genericResourceOperations.GetAsync();
            Assert.AreEqual(200, genericResource.GetRawResponse().Status);
        }

        [RecordedTest]
        public void GetGenericResourceOperationsWithSingleInvalidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(id));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public void GetGenericResourceOperationWithNullId()
        {
            ResourceIdentifier x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResource(x); });
        }

        [RecordedTest]
        [SyncOnly]
        public void ValidateMgmtTelemetry()
        {
            var options = new ArmClientOptions();
            options.Diagnostics.IsTelemetryEnabled = true;
            var client = GetArmClient(options);
            Assert.IsNotNull(GetPolicyFromPipeline(GetPipelineFromClient(client), nameof(MgmtTelemetryPolicy)));

            options.Diagnostics.IsTelemetryEnabled = false;
            client = GetArmClient(options);
            Assert.IsNull(GetPolicyFromPipeline(GetPipelineFromClient(client), nameof(MgmtTelemetryPolicy)));
            Assert.IsNull(GetPolicyFromPipeline(GetPipelineFromClient(client), "TelemetryPolicy"));
        }

        [RecordedTest]
        [SyncOnly]
        public void ValidateMgmtTelemetryComesAfterTelemetry()
        {
            var client = GetArmClient();
            var pipeline = GetPipelineFromClient(client);
            bool foundTelemetry = false;
            foreach (var policy in GetPoliciesFromPipeline(pipeline).ToArray())
            {
                foundTelemetry |= policy.GetType().Name == "TelemetryPolicy";
                if (policy.GetType() == typeof(MgmtTelemetryPolicy))
                {
                    Assert.IsTrue(foundTelemetry);
                    break;
                }
            }
        }

        private static HttpPipeline GetPipelineFromClient(ArmClient client)
        {
            var pipelineProperty = client.GetType().GetProperty("Pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);
            return pipelineProperty.GetValue(client) as HttpPipeline;
        }

        private object GetPolicyFromPipeline(HttpPipeline pipeline, string policyType)
        {
            ReadOnlyMemory<HttpPipelinePolicy> policies = GetPoliciesFromPipeline(pipeline);
            return policies.ToArray().FirstOrDefault(p => p.GetType().Name == policyType);
        }

        private static ReadOnlyMemory<HttpPipelinePolicy> GetPoliciesFromPipeline(HttpPipeline pipeline)
        {
            var policyField = pipeline.GetType().GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            policyField ??= pipeline.GetType().BaseType.GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            return (ReadOnlyMemory<HttpPipelinePolicy>)policyField.GetValue(pipeline);
        }
    }
}
