// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Communication
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((armClient) =>
            {
                return new SubscriptionExtensionClient(armClient, subscription.Id);
            }
            );
        }

        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="nameAvailabilityParameters"> Parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response<NameAvailability>> CheckCommunicationNameAvailabilityAsync(this Subscription subscription, NameAvailabilityOptions nameAvailabilityParameters = null, CancellationToken cancellationToken = default)
        {
            return await GetExtensionClient(subscription).CheckCommunicationNameAvailabilityAsync(nameAvailabilityParameters, cancellationToken).ConfigureAwait(false);
        }

        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="nameAvailabilityParameters"> Parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response<NameAvailability> CheckCommunicationNameAvailability(this Subscription subscription, NameAvailabilityOptions nameAvailabilityParameters = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).CheckCommunicationNameAvailability(nameAvailabilityParameters, cancellationToken);
        }

        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CommunicationService> GetCommunicationServicesAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetCommunicationServicesAsync(cancellationToken);
        }

        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<CommunicationService> GetCommunicationServices(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetCommunicationServices(cancellationToken);
        }
    }
}
