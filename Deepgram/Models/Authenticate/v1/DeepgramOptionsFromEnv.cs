﻿// Copyright 2021-2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Models.Authenticate.v1;

public class DeepgramOptionsFromEnv : IDeepgramClientOptions
{
    /*****************************/
    // General Options
    /*****************************/
    /// <summary>
    /// Deepgram API KEY
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// BaseAddress of the server :defaults to api.deepgram.com
    /// no need to attach the protocol it will be added internally
    /// </summary>
    public string BaseAddress { get; set; } = Defaults.DEFAULT_URI;

    /// <summary>
    /// Api endpoint version
    /// </summary>
    public string APIVersion { get; set; } = Defaults.DEFAULT_API_VERSION;

    /// <summary>
    /// Global headers to always be added to the request
    /// </summary>
    public Dictionary<string, string> Headers { get; set; }

    /*****************************/
    // Prerecorded
    /*****************************/

    /*****************************/
    // Live
    /*****************************/
    /// <summary>
    /// Enable sending KeepAlives for Streaming
    /// </summary>
    public bool KeepAlive { get; set; } = false;

    /*****************************/
    // OnPrem
    /*****************************/
    /// <summary>
    /// Enable when using OnPrem mode
    /// </summary>
    public bool OnPrem { get; set; } = false;

    /*****************************/
    // Manage
    /*****************************/

    /*****************************/
    // Analyze
    /*****************************/

    /*****************************/
    // Speak
    /*****************************/

    /*****************************/
    // Constructor
    /*****************************/

    public DeepgramOptionsFromEnv()
    {
        ApiKey = Environment.GetEnvironmentVariable("DEEPGRAM_API_KEY") ?? "";
        BaseAddress = Environment.GetEnvironmentVariable("DEEPGRAM_HOST") ?? Defaults.DEFAULT_URI;
        APIVersion = Environment.GetEnvironmentVariable("DEEPGRAM_API_VERSION") ?? Defaults.DEFAULT_API_VERSION;
        var onPrem = Environment.GetEnvironmentVariable("DEEPGRAM_ON_PREM") ?? "";
        var keepAlive = Environment.GetEnvironmentVariable("DEEPGRAM_KEEP_ALIVE") ?? "";

        Headers = new Dictionary<string, string>();
        for (int x = 0; x < 20; x++)
        {
            var param = Environment.GetEnvironmentVariable($"DEEPGRAM_PARAM_{x}");
            if (param != null)
            {
                var value = Environment.GetEnvironmentVariable($"DEEPGRAM_PARAM_VALUE_{x}") ?? "";
                Headers[param] = value;
            }
            else
            {
                break;
            }
        }

        OnPrem = onPrem.ToLower() == "true";
        KeepAlive = keepAlive.ToLower() == "true";
    }

}
