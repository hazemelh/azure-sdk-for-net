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
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of VnetInfoResource and their operations over its parent. </summary>
    public partial class SiteSlotVirtualNetworkConnectionCollection : ArmCollection, IEnumerable<SiteSlotVirtualNetworkConnection>, IAsyncEnumerable<SiteSlotVirtualNetworkConnection>
    {
        private readonly ClientDiagnostics _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotVirtualNetworkConnectionWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotVirtualNetworkConnectionCollection"/> class for mocking. </summary>
        protected SiteSlotVirtualNetworkConnectionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotVirtualNetworkConnectionCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SiteSlotVirtualNetworkConnectionCollection(ArmResource parent) : base(parent)
        {
            _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotVirtualNetworkConnection.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(SiteSlotVirtualNetworkConnection.ResourceType, out string siteSlotVirtualNetworkConnectionWebAppsApiVersion);
            _siteSlotVirtualNetworkConnectionWebAppsRestClient = new WebAppsRestOperations(_siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotVirtualNetworkConnectionWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteSlot.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteSlot.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}
        /// OperationId: WebApps_CreateOrUpdateVnetConnectionSlot
        /// <summary> Description for Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH). </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="vnetName"> Name of an existing Virtual Network. </param>
        /// <param name="connectionEnvelope"> Properties of the Virtual Network connection. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> or <paramref name="connectionEnvelope"/> is null. </exception>
        public virtual SiteSlotVirtualNetworkConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vnetName, VnetInfoResourceData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));
            if (connectionEnvelope == null)
            {
                throw new ArgumentNullException(nameof(connectionEnvelope));
            }

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteSlotVirtualNetworkConnectionWebAppsRestClient.CreateOrUpdateVnetConnectionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vnetName, connectionEnvelope, cancellationToken);
                var operation = new SiteSlotVirtualNetworkConnectionCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}
        /// OperationId: WebApps_CreateOrUpdateVnetConnectionSlot
        /// <summary> Description for Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH). </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="vnetName"> Name of an existing Virtual Network. </param>
        /// <param name="connectionEnvelope"> Properties of the Virtual Network connection. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> or <paramref name="connectionEnvelope"/> is null. </exception>
        public async virtual Task<SiteSlotVirtualNetworkConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vnetName, VnetInfoResourceData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));
            if (connectionEnvelope == null)
            {
                throw new ArgumentNullException(nameof(connectionEnvelope));
            }

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteSlotVirtualNetworkConnectionWebAppsRestClient.CreateOrUpdateVnetConnectionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vnetName, connectionEnvelope, cancellationToken).ConfigureAwait(false);
                var operation = new SiteSlotVirtualNetworkConnectionCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}
        /// OperationId: WebApps_GetVnetConnectionSlot
        /// <summary> Description for Gets a virtual network the app (or deployment slot) is connected to by name. </summary>
        /// <param name="vnetName"> Name of the virtual network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> is null. </exception>
        public virtual Response<SiteSlotVirtualNetworkConnection> Get(string vnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotVirtualNetworkConnectionWebAppsRestClient.GetVnetConnectionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vnetName, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotVirtualNetworkConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}
        /// OperationId: WebApps_GetVnetConnectionSlot
        /// <summary> Description for Gets a virtual network the app (or deployment slot) is connected to by name. </summary>
        /// <param name="vnetName"> Name of the virtual network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> is null. </exception>
        public async virtual Task<Response<SiteSlotVirtualNetworkConnection>> GetAsync(string vnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotVirtualNetworkConnectionWebAppsRestClient.GetVnetConnectionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vnetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotVirtualNetworkConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vnetName"> Name of the virtual network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> is null. </exception>
        public virtual Response<SiteSlotVirtualNetworkConnection> GetIfExists(string vnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotVirtualNetworkConnectionWebAppsRestClient.GetVnetConnectionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vnetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotVirtualNetworkConnection>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotVirtualNetworkConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vnetName"> Name of the virtual network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> is null. </exception>
        public async virtual Task<Response<SiteSlotVirtualNetworkConnection>> GetIfExistsAsync(string vnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotVirtualNetworkConnectionWebAppsRestClient.GetVnetConnectionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vnetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotVirtualNetworkConnection>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotVirtualNetworkConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vnetName"> Name of the virtual network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> is null. </exception>
        public virtual Response<bool> Exists(string vnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(vnetName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vnetName"> Name of the virtual network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vnetName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string vnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vnetName, nameof(vnetName));

            using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vnetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}
        /// OperationId: WebApps_ListVnetConnectionsSlot
        /// <summary> Description for Gets the virtual networks the app (or deployment slot) is connected to. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteSlotVirtualNetworkConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteSlotVirtualNetworkConnection> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteSlotVirtualNetworkConnection> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotVirtualNetworkConnectionWebAppsRestClient.ListVnetConnectionsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Select(value => new SiteSlotVirtualNetworkConnection(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}
        /// OperationId: WebApps_ListVnetConnectionsSlot
        /// <summary> Description for Gets the virtual networks the app (or deployment slot) is connected to. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteSlotVirtualNetworkConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteSlotVirtualNetworkConnection> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteSlotVirtualNetworkConnection>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteSlotVirtualNetworkConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotVirtualNetworkConnectionWebAppsRestClient.ListVnetConnectionsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Select(value => new SiteSlotVirtualNetworkConnection(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<SiteSlotVirtualNetworkConnection> IEnumerable<SiteSlotVirtualNetworkConnection>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteSlotVirtualNetworkConnection> IAsyncEnumerable<SiteSlotVirtualNetworkConnection>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
