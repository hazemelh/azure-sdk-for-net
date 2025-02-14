// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a LoadBalancer along with the instance operations that can be performed on it. </summary>
    public partial class LoadBalancer : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="LoadBalancer"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadBalancerName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _loadBalancerClientDiagnostics;
        private readonly LoadBalancersRestOperations _loadBalancerRestClient;
        private readonly ClientDiagnostics _loadBalancerNetworkInterfacesClientDiagnostics;
        private readonly LoadBalancerNetworkInterfacesRestOperations _loadBalancerNetworkInterfacesRestClient;
        private readonly LoadBalancerData _data;

        /// <summary> Initializes a new instance of the <see cref="LoadBalancer"/> class for mocking. </summary>
        protected LoadBalancer()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "LoadBalancer"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal LoadBalancer(ArmClient armClient, LoadBalancerData data) : this(armClient, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="LoadBalancer"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal LoadBalancer(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
            _loadBalancerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ResourceType, out string loadBalancerApiVersion);
            _loadBalancerRestClient = new LoadBalancersRestOperations(_loadBalancerClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, loadBalancerApiVersion);
            _loadBalancerNetworkInterfacesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _loadBalancerNetworkInterfacesRestClient = new LoadBalancerNetworkInterfacesRestOperations(_loadBalancerNetworkInterfacesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/loadBalancers";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual LoadBalancerData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets the specified load balancer. </summary>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<LoadBalancer>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.Get");
            scope.Start();
            try
            {
                var response = await _loadBalancerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _loadBalancerClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new LoadBalancer(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified load balancer. </summary>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LoadBalancer> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.Get");
            scope.Start();
            try
            {
                var response = _loadBalancerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw _loadBalancerClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LoadBalancer(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.GetAvailableLocations");
            scope.Start();
            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.GetAvailableLocations");
            scope.Start();
            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified load balancer. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<LoadBalancerDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.Delete");
            scope.Start();
            try
            {
                var response = await _loadBalancerRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new LoadBalancerDeleteOperation(_loadBalancerClientDiagnostics, Pipeline, _loadBalancerRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified load balancer. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LoadBalancerDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.Delete");
            scope.Start();
            try
            {
                var response = _loadBalancerRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new LoadBalancerDeleteOperation(_loadBalancerClientDiagnostics, Pipeline, _loadBalancerRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a load balancer tags. </summary>
        /// <param name="parameters"> Parameters supplied to update load balancer tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<LoadBalancer>> UpdateAsync(TagsObject parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.Update");
            scope.Start();
            try
            {
                var response = await _loadBalancerRestClient.UpdateTagsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new LoadBalancer(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a load balancer tags. </summary>
        /// <param name="parameters"> Parameters supplied to update load balancer tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<LoadBalancer> Update(TagsObject parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancer.Update");
            scope.Start();
            try
            {
                var response = _loadBalancerRestClient.UpdateTags(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                return Response.FromValue(new LoadBalancer(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets associated load balancer network interfaces. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkInterfaceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkInterfaceData> GetLoadBalancerNetworkInterfacesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NetworkInterfaceData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _loadBalancerNetworkInterfacesClientDiagnostics.CreateScope("LoadBalancer.GetLoadBalancerNetworkInterfaces");
                scope.Start();
                try
                {
                    var response = await _loadBalancerNetworkInterfacesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<NetworkInterfaceData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _loadBalancerNetworkInterfacesClientDiagnostics.CreateScope("LoadBalancer.GetLoadBalancerNetworkInterfaces");
                scope.Start();
                try
                {
                    var response = await _loadBalancerNetworkInterfacesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets associated load balancer network interfaces. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkInterfaceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkInterfaceData> GetLoadBalancerNetworkInterfaces(CancellationToken cancellationToken = default)
        {
            Page<NetworkInterfaceData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _loadBalancerNetworkInterfacesClientDiagnostics.CreateScope("LoadBalancer.GetLoadBalancerNetworkInterfaces");
                scope.Start();
                try
                {
                    var response = _loadBalancerNetworkInterfacesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<NetworkInterfaceData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _loadBalancerNetworkInterfacesClientDiagnostics.CreateScope("LoadBalancer.GetLoadBalancerNetworkInterfaces");
                scope.Start();
                try
                {
                    var response = _loadBalancerNetworkInterfacesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        #region BackendAddressPool

        /// <summary> Gets a collection of BackendAddressPools in the LoadBalancer. </summary>
        /// <returns> An object representing collection of BackendAddressPools and their operations over a LoadBalancer. </returns>
        public virtual BackendAddressPoolCollection GetBackendAddressPools()
        {
            return new BackendAddressPoolCollection(this);
        }
        #endregion

        #region FrontendIPConfiguration

        /// <summary> Gets a collection of FrontendIPConfigurations in the LoadBalancer. </summary>
        /// <returns> An object representing collection of FrontendIPConfigurations and their operations over a LoadBalancer. </returns>
        public virtual FrontendIPConfigurationCollection GetFrontendIPConfigurations()
        {
            return new FrontendIPConfigurationCollection(this);
        }
        #endregion

        #region InboundNatRule

        /// <summary> Gets a collection of InboundNatRules in the LoadBalancer. </summary>
        /// <returns> An object representing collection of InboundNatRules and their operations over a LoadBalancer. </returns>
        public virtual InboundNatRuleCollection GetInboundNatRules()
        {
            return new InboundNatRuleCollection(this);
        }
        #endregion

        #region LoadBalancingRule

        /// <summary> Gets a collection of LoadBalancingRules in the LoadBalancer. </summary>
        /// <returns> An object representing collection of LoadBalancingRules and their operations over a LoadBalancer. </returns>
        public virtual LoadBalancingRuleCollection GetLoadBalancingRules()
        {
            return new LoadBalancingRuleCollection(this);
        }
        #endregion

        #region OutboundRule

        /// <summary> Gets a collection of OutboundRules in the LoadBalancer. </summary>
        /// <returns> An object representing collection of OutboundRules and their operations over a LoadBalancer. </returns>
        public virtual OutboundRuleCollection GetOutboundRules()
        {
            return new OutboundRuleCollection(this);
        }
        #endregion

        #region Probe

        /// <summary> Gets a collection of Probes in the LoadBalancer. </summary>
        /// <returns> An object representing collection of Probes and their operations over a LoadBalancer. </returns>
        public virtual ProbeCollection GetProbes()
        {
            return new ProbeCollection(this);
        }
        #endregion
    }
}
