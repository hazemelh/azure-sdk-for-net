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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of LocalNetworkGateway and their operations over its parent. </summary>
    public partial class LocalNetworkGatewayCollection : ArmCollection, IEnumerable<LocalNetworkGateway>, IAsyncEnumerable<LocalNetworkGateway>
    {
        private readonly ClientDiagnostics _localNetworkGatewayClientDiagnostics;
        private readonly LocalNetworkGatewaysRestOperations _localNetworkGatewayRestClient;

        /// <summary> Initializes a new instance of the <see cref="LocalNetworkGatewayCollection"/> class for mocking. </summary>
        protected LocalNetworkGatewayCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="LocalNetworkGatewayCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal LocalNetworkGatewayCollection(ArmResource parent) : base(parent)
        {
            _localNetworkGatewayClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", LocalNetworkGateway.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(LocalNetworkGateway.ResourceType, out string localNetworkGatewayApiVersion);
            _localNetworkGatewayRestClient = new LocalNetworkGatewaysRestOperations(_localNetworkGatewayClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, localNetworkGatewayApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// <summary> Creates or updates a local network gateway in the specified resource group. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="parameters"> Parameters supplied to the create or update local network gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual LocalNetworkGatewayCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string localNetworkGatewayName, LocalNetworkGatewayData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _localNetworkGatewayRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, parameters, cancellationToken);
                var operation = new LocalNetworkGatewayCreateOrUpdateOperation(ArmClient, _localNetworkGatewayClientDiagnostics, Pipeline, _localNetworkGatewayRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, parameters).Request, response);
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

        /// <summary> Creates or updates a local network gateway in the specified resource group. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="parameters"> Parameters supplied to the create or update local network gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<LocalNetworkGatewayCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string localNetworkGatewayName, LocalNetworkGatewayData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _localNetworkGatewayRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new LocalNetworkGatewayCreateOrUpdateOperation(ArmClient, _localNetworkGatewayClientDiagnostics, Pipeline, _localNetworkGatewayRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, parameters).Request, response);
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

        /// <summary> Gets the specified local network gateway in a resource group. </summary>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> is null. </exception>
        public virtual Response<LocalNetworkGateway> Get(string localNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = _localNetworkGatewayRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, cancellationToken);
                if (response.Value == null)
                    throw _localNetworkGatewayClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LocalNetworkGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified local network gateway in a resource group. </summary>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> is null. </exception>
        public async virtual Task<Response<LocalNetworkGateway>> GetAsync(string localNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = await _localNetworkGatewayRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _localNetworkGatewayClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new LocalNetworkGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> is null. </exception>
        public virtual Response<LocalNetworkGateway> GetIfExists(string localNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _localNetworkGatewayRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<LocalNetworkGateway>(null, response.GetRawResponse());
                return Response.FromValue(new LocalNetworkGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> is null. </exception>
        public async virtual Task<Response<LocalNetworkGateway>> GetIfExistsAsync(string localNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _localNetworkGatewayRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, localNetworkGatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<LocalNetworkGateway>(null, response.GetRawResponse());
                return Response.FromValue(new LocalNetworkGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> is null. </exception>
        public virtual Response<bool> Exists(string localNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(localNetworkGatewayName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="localNetworkGatewayName"> The name of the local network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="localNetworkGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="localNetworkGatewayName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string localNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(localNetworkGatewayName, nameof(localNetworkGatewayName));

            using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(localNetworkGatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all the local network gateways in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LocalNetworkGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LocalNetworkGateway> GetAll(CancellationToken cancellationToken = default)
        {
            Page<LocalNetworkGateway> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _localNetworkGatewayRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LocalNetworkGateway(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<LocalNetworkGateway> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _localNetworkGatewayRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LocalNetworkGateway(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all the local network gateways in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="LocalNetworkGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LocalNetworkGateway> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<LocalNetworkGateway>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _localNetworkGatewayRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LocalNetworkGateway(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<LocalNetworkGateway>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _localNetworkGatewayClientDiagnostics.CreateScope("LocalNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _localNetworkGatewayRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LocalNetworkGateway(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<LocalNetworkGateway> IEnumerable<LocalNetworkGateway>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<LocalNetworkGateway> IAsyncEnumerable<LocalNetworkGateway>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
