// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.ConnectedVMwarevSphere
{
    /// <summary> A class representing collection of GuestAgent and their operations over its parent. </summary>
    public partial class GuestAgentCollection : ArmCollection, IEnumerable<GuestAgent>, IAsyncEnumerable<GuestAgent>
    {
        private readonly ClientDiagnostics _guestAgentClientDiagnostics;
        private readonly GuestAgentsRestOperations _guestAgentRestClient;

        /// <summary> Initializes a new instance of the <see cref="GuestAgentCollection"/> class for mocking. </summary>
        protected GuestAgentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="GuestAgentCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal GuestAgentCollection(ArmResource parent) : base(parent)
        {
            _guestAgentClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ConnectedVMwarevSphere", GuestAgent.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(GuestAgent.ResourceType, out string guestAgentApiVersion);
            _guestAgentRestClient = new GuestAgentsRestOperations(_guestAgentClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, guestAgentApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualMachine.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualMachine.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/guestAgents/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}
        /// OperationId: GuestAgents_Create
        /// <summary> Create Or Update GuestAgent. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> Name of the guestAgents. </param>
        /// <param name="body"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual GuestAgentCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string name, GuestAgentData body = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _guestAgentRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, body, cancellationToken);
                var operation = new GuestAgentCreateOrUpdateOperation(ArmClient, _guestAgentClientDiagnostics, Pipeline, _guestAgentRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, body).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/guestAgents/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}
        /// OperationId: GuestAgents_Create
        /// <summary> Create Or Update GuestAgent. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> Name of the guestAgents. </param>
        /// <param name="body"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<GuestAgentCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string name, GuestAgentData body = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _guestAgentRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, body, cancellationToken).ConfigureAwait(false);
                var operation = new GuestAgentCreateOrUpdateOperation(ArmClient, _guestAgentClientDiagnostics, Pipeline, _guestAgentRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, body).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/guestAgents/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}
        /// OperationId: GuestAgents_Get
        /// <summary> Implements GuestAgent GET method. </summary>
        /// <param name="name"> Name of the GuestAgent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<GuestAgent> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.Get");
            scope.Start();
            try
            {
                var response = _guestAgentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken);
                if (response.Value == null)
                    throw _guestAgentClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GuestAgent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/guestAgents/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}
        /// OperationId: GuestAgents_Get
        /// <summary> Implements GuestAgent GET method. </summary>
        /// <param name="name"> Name of the GuestAgent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<GuestAgent>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.Get");
            scope.Start();
            try
            {
                var response = await _guestAgentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _guestAgentClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new GuestAgent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> Name of the GuestAgent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<GuestAgent> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _guestAgentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<GuestAgent>(null, response.GetRawResponse());
                return Response.FromValue(new GuestAgent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> Name of the GuestAgent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<GuestAgent>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _guestAgentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<GuestAgent>(null, response.GetRawResponse());
                return Response.FromValue(new GuestAgent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> Name of the GuestAgent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> Name of the GuestAgent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/guestAgents
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}
        /// OperationId: GuestAgents_ListByVm
        /// <summary> Returns the list of GuestAgent of the given vm. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestAgent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GuestAgent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<GuestAgent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _guestAgentRestClient.ListByVm(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new GuestAgent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<GuestAgent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _guestAgentRestClient.ListByVmNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new GuestAgent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/guestAgents
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}
        /// OperationId: GuestAgents_ListByVm
        /// <summary> Returns the list of GuestAgent of the given vm. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestAgent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GuestAgent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<GuestAgent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _guestAgentRestClient.ListByVmAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new GuestAgent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<GuestAgent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _guestAgentClientDiagnostics.CreateScope("GuestAgentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _guestAgentRestClient.ListByVmNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new GuestAgent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<GuestAgent> IEnumerable<GuestAgent>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<GuestAgent> IAsyncEnumerable<GuestAgent>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
