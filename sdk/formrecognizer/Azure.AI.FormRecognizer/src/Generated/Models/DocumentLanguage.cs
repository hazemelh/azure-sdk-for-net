// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary> An object representing the detected language for a given text span. </summary>
    internal partial class DocumentLanguage
    {
        /// <summary> Initializes a new instance of DocumentLanguage. </summary>
        /// <param name="languageCode"> Detected language.  Value may an ISO 639-1 language code (ex. &quot;en&quot;, &quot;fr&quot;) or BCP 47 language tag (ex. &quot;zh-Hans&quot;). </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the language applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the language. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="languageCode"/> or <paramref name="spans"/> is null. </exception>
        internal DocumentLanguage(string languageCode, IEnumerable<DocumentSpan> spans, float confidence)
        {
            if (languageCode == null)
            {
                throw new ArgumentNullException(nameof(languageCode));
            }
            if (spans == null)
            {
                throw new ArgumentNullException(nameof(spans));
            }

            LanguageCode = languageCode;
            Spans = spans.ToList();
            Confidence = confidence;
        }

        /// <summary> Initializes a new instance of DocumentLanguage. </summary>
        /// <param name="languageCode"> Detected language.  Value may an ISO 639-1 language code (ex. &quot;en&quot;, &quot;fr&quot;) or BCP 47 language tag (ex. &quot;zh-Hans&quot;). </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the language applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the language. </param>
        internal DocumentLanguage(string languageCode, IReadOnlyList<DocumentSpan> spans, float confidence)
        {
            LanguageCode = languageCode;
            Spans = spans;
            Confidence = confidence;
        }

        /// <summary> Detected language.  Value may an ISO 639-1 language code (ex. &quot;en&quot;, &quot;fr&quot;) or BCP 47 language tag (ex. &quot;zh-Hans&quot;). </summary>
        public string LanguageCode { get; }
        /// <summary> Location of the text elements in the concatenated content the language applies to. </summary>
        public IReadOnlyList<DocumentSpan> Spans { get; }
        /// <summary> Confidence of correctly identifying the language. </summary>
        public float Confidence { get; }
    }
}
