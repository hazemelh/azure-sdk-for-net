// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.KeyVault
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region Vault
        /// <summary> Gets an object representing a VaultCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="VaultCollection" /> object. </returns>
        public static VaultCollection GetVaults(this ResourceGroup resourceGroup)
        {
            return new VaultCollection(resourceGroup);
        }
        #endregion

        #region ManagedHsm
        /// <summary> Gets an object representing a ManagedHsmCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="ManagedHsmCollection" /> object. </returns>
        public static ManagedHsmCollection GetManagedHsms(this ResourceGroup resourceGroup)
        {
            return new ManagedHsmCollection(resourceGroup);
        }
        #endregion

        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((armClient) =>
            {
                return new ResourceGroupExtensionClient(armClient, resourceGroup.Id);
            }
            );
        }
    }
}
