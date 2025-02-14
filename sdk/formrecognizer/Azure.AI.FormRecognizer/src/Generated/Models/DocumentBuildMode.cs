// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary> Custom model build mode. </summary>
    internal readonly partial struct DocumentBuildMode : IEquatable<DocumentBuildMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DocumentBuildMode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DocumentBuildMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TemplateValue = "template";
        private const string NeuralValue = "neural";

        /// <summary> template. </summary>
        public static DocumentBuildMode Template { get; } = new DocumentBuildMode(TemplateValue);
        /// <summary> neural. </summary>
        public static DocumentBuildMode Neural { get; } = new DocumentBuildMode(NeuralValue);
        /// <summary> Determines if two <see cref="DocumentBuildMode"/> values are the same. </summary>
        public static bool operator ==(DocumentBuildMode left, DocumentBuildMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentBuildMode"/> values are not the same. </summary>
        public static bool operator !=(DocumentBuildMode left, DocumentBuildMode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DocumentBuildMode"/>. </summary>
        public static implicit operator DocumentBuildMode(string value) => new DocumentBuildMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DocumentBuildMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DocumentBuildMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
