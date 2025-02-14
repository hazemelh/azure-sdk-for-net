// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.StoragePool
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region DiskPool
        /// <summary> Gets an object representing a DiskPool along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DiskPool" /> object. </returns>
        public static DiskPool GetDiskPool(this ArmClient armClient, ResourceIdentifier id)
        {
            DiskPool.ValidateResourceId(id);
            return new DiskPool(armClient, id);
        }
        #endregion

        #region IscsiTarget
        /// <summary> Gets an object representing a IscsiTarget along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="IscsiTarget" /> object. </returns>
        public static IscsiTarget GetIscsiTarget(this ArmClient armClient, ResourceIdentifier id)
        {
            IscsiTarget.ValidateResourceId(id);
            return new IscsiTarget(armClient, id);
        }
        #endregion
    }
}
