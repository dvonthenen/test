﻿// Copyright 2021-2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Models.PreRecorded.v1;

public class IntentSchema
{
    /// <summary>
    /// Enables intent recognition
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("intents")]
    public bool? Intents { get; set; }

    /// <summary>
    /// The language of your input audio (Only english is supported at this time)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("language")]
    public string? Language { get; set; } = "en";

    /// <summary>
    /// Optional. A custom intent you want the model to detect within your input audio if present. Submit up to 100.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("custom_intent")]
    public string? CustomIntent { get; set; }

    /// <summary>
    /// Optional. Sets how the model will interpret strings submitted to the custom_intent param. When "strict", the model will only return intents submitted using the custom_intent param. When "extended", the model will return it's own detected intents in addition those submitted using the custom_intents param.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("custom_intent_mode")]
    public string? CustomIntentMode { get; set; }
}
