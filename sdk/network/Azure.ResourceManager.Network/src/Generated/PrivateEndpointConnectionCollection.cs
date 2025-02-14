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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of PrivateEndpointConnection and their operations over its parent. </summary>
    public partial class PrivateEndpointConnectionCollection : ArmCollection, IEnumerable<PrivateEndpointConnection>, IAsyncEnumerable<PrivateEndpointConnection>
    {
        private readonly ClientDiagnostics _privateEndpointConnectionPrivateLinkServicesClientDiagnostics;
        private readonly PrivateLinkServicesRestOperations _privateEndpointConnectionPrivateLinkServicesRestClient;

        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointConnectionCollection"/> class for mocking. </summary>
        protected PrivateEndpointConnectionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointConnectionCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal PrivateEndpointConnectionCollection(ArmResource parent) : base(parent)
        {
            _privateEndpointConnectionPrivateLinkServicesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", PrivateEndpointConnection.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(PrivateEndpointConnection.ResourceType, out string privateEndpointConnectionPrivateLinkServicesApiVersion);
            _privateEndpointConnectionPrivateLinkServicesRestClient = new PrivateLinkServicesRestOperations(_privateEndpointConnectionPrivateLinkServicesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, privateEndpointConnectionPrivateLinkServicesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != PrivateLinkService.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, PrivateLinkService.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// <summary> Approve or reject private end point connection for a private link service in a subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="parameters"> Parameters supplied to approve or reject the private end point connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string peConnectionName, PrivateEndpointConnectionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _privateEndpointConnectionPrivateLinkServicesRestClient.UpdatePrivateEndpointConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peConnectionName, parameters, cancellationToken);
                var operation = new PrivateEndpointConnectionCreateOrUpdateOperation(ArmClient, response);
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

        /// <summary> Approve or reject private end point connection for a private link service in a subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="parameters"> Parameters supplied to approve or reject the private end point connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string peConnectionName, PrivateEndpointConnectionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _privateEndpointConnectionPrivateLinkServicesRestClient.UpdatePrivateEndpointConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peConnectionName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new PrivateEndpointConnectionCreateOrUpdateOperation(ArmClient, response);
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

        /// <summary> Get the specific private end point connection by specific private link service in the resource group. </summary>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> is null. </exception>
        public virtual Response<PrivateEndpointConnection> Get(string peConnectionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = _privateEndpointConnectionPrivateLinkServicesRestClient.GetPrivateEndpointConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peConnectionName, expand, cancellationToken);
                if (response.Value == null)
                    throw _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateEndpointConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the specific private end point connection by specific private link service in the resource group. </summary>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> is null. </exception>
        public async virtual Task<Response<PrivateEndpointConnection>> GetAsync(string peConnectionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = await _privateEndpointConnectionPrivateLinkServicesRestClient.GetPrivateEndpointConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peConnectionName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PrivateEndpointConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> is null. </exception>
        public virtual Response<PrivateEndpointConnection> GetIfExists(string peConnectionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _privateEndpointConnectionPrivateLinkServicesRestClient.GetPrivateEndpointConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peConnectionName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PrivateEndpointConnection>(null, response.GetRawResponse());
                return Response.FromValue(new PrivateEndpointConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> is null. </exception>
        public async virtual Task<Response<PrivateEndpointConnection>> GetIfExistsAsync(string peConnectionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _privateEndpointConnectionPrivateLinkServicesRestClient.GetPrivateEndpointConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peConnectionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PrivateEndpointConnection>(null, response.GetRawResponse());
                return Response.FromValue(new PrivateEndpointConnection(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> is null. </exception>
        public virtual Response<bool> Exists(string peConnectionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(peConnectionName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="peConnectionName"> The name of the private end point connection. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peConnectionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string peConnectionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peConnectionName, nameof(peConnectionName));

            using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(peConnectionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all private end point connections for a specific private link service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateEndpointConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateEndpointConnection> GetAll(CancellationToken cancellationToken = default)
        {
            Page<PrivateEndpointConnection> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _privateEndpointConnectionPrivateLinkServicesRestClient.ListPrivateEndpointConnections(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpointConnection(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PrivateEndpointConnection> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _privateEndpointConnectionPrivateLinkServicesRestClient.ListPrivateEndpointConnectionsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpointConnection(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all private end point connections for a specific private link service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PrivateEndpointConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateEndpointConnection> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PrivateEndpointConnection>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _privateEndpointConnectionPrivateLinkServicesRestClient.ListPrivateEndpointConnectionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpointConnection(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PrivateEndpointConnection>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _privateEndpointConnectionPrivateLinkServicesClientDiagnostics.CreateScope("PrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _privateEndpointConnectionPrivateLinkServicesRestClient.ListPrivateEndpointConnectionsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpointConnection(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<PrivateEndpointConnection> IEnumerable<PrivateEndpointConnection>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PrivateEndpointConnection> IAsyncEnumerable<PrivateEndpointConnection>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
