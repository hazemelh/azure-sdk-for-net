﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// Represents a project for the Conversations service
    /// </summary>
    public class ConversationsProject
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ConversationsProject"/> class
        /// </summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "production".</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/> or <paramref name="deploymentName"/> is null.</exception>
        public ConversationsProject(string projectName, string deploymentName)
        {
            ProjectName = Argument.CheckNotNull(projectName, nameof(projectName));
            DeploymentName = Argument.CheckNotNull(deploymentName, nameof(deploymentName));
        }

        /// <summary>
        /// Gets the name of the project to use.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Gets the deployment name of the project to use, such as "test" or "production".
        /// </summary>
        public string DeploymentName { get; }
    }
}
