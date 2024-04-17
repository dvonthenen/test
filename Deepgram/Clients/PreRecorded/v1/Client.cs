﻿// Copyright 2021-2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

using Deepgram.Models.Authenticate.v1;
using Deepgram.Models.PreRecorded.v1;
using Deepgram.Clients.Interfaces.v1;

namespace Deepgram.Clients.PreRecorded.v1;

/// <summary>
/// Implements version 1 of the Analyze Client.
/// </summary>
/// <param name="apiKey">Required DeepgramApiKey</param>
/// <param name="deepgramClientOptions"><see cref="DeepgramHttpClientOptions"/> for HttpClient Configuration</param>
public class Client(string? apiKey = null, IDeepgramClientOptions? deepgramClientOptions = null, string? httpId = null)
    : AbstractRestClient(apiKey, deepgramClientOptions, httpId), IPreRecordedClient

{
    #region NoneCallBacks
    /// <summary>
    ///  Transcribe a file by providing a url 
    /// </summary>
    /// <param name="source">Url to the file that is to be transcribed <see cref="UrlSource"></param>
    /// <param name="prerecordedSchema">Options for the transcription <see cref="PrerecordedSchema"/></param>
    /// <returns><see cref="SyncResponse"/></returns>
    public async Task<SyncResponse> TranscribeUrl(UrlSource source, PrerecordedSchema? prerecordedSchema,
        CancellationTokenSource? cancellationToken = default, Dictionary<string, string>? addons = null, Dictionary<string, string>? headers = null)
    {
        Log.Verbose("PreRecordedClient.TranscribeUrl", "ENTER");
        Log.Information("TranscribeUrl", $"source: {source}");
        Log.Information("TranscribeUrl", $"prerecordedSchema:\n{JsonSerializer.Serialize(prerecordedSchema, JsonSerializeOptions.DefaultOptions)}");

        VerifyNoCallBack(nameof(TranscribeUrl), prerecordedSchema);

        var uri = GetUri(_options, $"{UriSegments.LISTEN}");
        var result = await PostAsync<UrlSource, PrerecordedSchema, SyncResponse>( uri, prerecordedSchema, source, cancellationToken, addons, headers);

        Log.Information("TranscribeUrl", $"{uri} Succeeded");
        Log.Debug("TranscribeUrl", $"result: {result}");
        Log.Verbose("PreRecordedClient.TranscribeUrl", "LEAVE");

        return result;
    }

    /// <summary>
    /// Transcribes a file using the provided byte array
    /// </summary>
    /// <param name="source">file is the form of a byte[]</param>
    /// <param name="prerecordedSchema">Options for the transcription <see cref="PrerecordedSchema"/></param>
    /// <returns><see cref="SyncResponse"/></returns>
    public async Task<SyncResponse> TranscribeFile(byte[] source, PrerecordedSchema? prerecordedSchema,
        CancellationTokenSource? cancellationToken = default, Dictionary<string, string>? addons = null, Dictionary<string, string>? headers = null)
    {
        MemoryStream stream = new MemoryStream(source);
        return await TranscribeFile(stream, prerecordedSchema, cancellationToken, addons, headers);
    }

    /// <summary>
    /// Transcribes a file using the provided stream
    /// </summary>
    /// <param name="source">file is the form of a streasm <see cref="Stream"/></param>
    /// <param name="prerecordedSchema">Options for the transcription <see cref="PrerecordedSchema"/></param>
    /// <returns><see cref="SyncResponse"/></returns>
    public async Task<SyncResponse> TranscribeFile(Stream source, PrerecordedSchema? prerecordedSchema, CancellationTokenSource? cancellationToken = default, Dictionary<string, string>? addons = null, Dictionary<string, string>? headers = null)
    {
        Log.Verbose("PreRecordedClient.TranscribeFile", "ENTER");
        Log.Information("TranscribeFile", $"source: {source}");
        Log.Information("TranscribeFile", $"prerecordedSchema:\n{JsonSerializer.Serialize(prerecordedSchema, JsonSerializeOptions.DefaultOptions)}");

        VerifyNoCallBack(nameof(TranscribeFile), prerecordedSchema);

        var uri = GetUri(_options, $"{UriSegments.LISTEN}");
        var result = await PostAsync<Stream, PrerecordedSchema, SyncResponse>(uri, prerecordedSchema, source, cancellationToken, addons, headers);

        Log.Information("TranscribeFile", $"{uri} Succeeded");
        Log.Debug("TranscribeFile", $"result: {result}");
        Log.Verbose("PreRecordedClient.TranscribeFile", "LEAVE");

        return result;
    }

    #endregion

    #region  CallBack Methods
    /// <summary>
    /// Transcribes a file using the provided byte array and providing a CallBack
    /// </summary>
    /// <param name="source">file is the form of a byte[]</param>  
    /// <param name="callBack">CallBack url</param>    
    /// <param name="prerecordedSchema">Options for the transcription<see cref="PrerecordedSchema"></param>
    /// <returns><see cref="AsyncResponse"/></returns>
    public async Task<AsyncResponse> TranscribeFileCallBack(byte[] source, string? callBack, PrerecordedSchema? prerecordedSchema, CancellationTokenSource? cancellationToken = default, Dictionary<string, string>? addons = null, Dictionary<string, string>? headers = null)
    {
        MemoryStream stream = new MemoryStream(source);
        return await TranscribeFileCallBack(stream, callBack, prerecordedSchema, cancellationToken, addons, headers);
    }

    /// <summary>
    /// Transcribes a file using the provided stream and providing a CallBack
    /// </summary>
    /// <param name="source">file is the form of a stream <see cref="Stream"></param>  
    /// <param name="callBack">CallBack url</param>    
    /// <param name="prerecordedSchema">Options for the transcription<see cref="PrerecordedSchema"></param>
    /// <returns><see cref="AsyncResponse"/></returns>
    public async Task<AsyncResponse> TranscribeFileCallBack(Stream source, string? callBack, PrerecordedSchema? prerecordedSchema, CancellationTokenSource? cancellationToken = default, Dictionary<string, string>? addons = null, Dictionary<string, string>? headers = null)
    {
        Log.Verbose("PreRecordedClient.TranscribeFileCallBack", "ENTER");
        Log.Information("TranscribeFileCallBack", $"source: {source}");
        Log.Information("TranscribeFileCallBack", $"callBack: {callBack}");
        Log.Information("TranscribeFileCallBack", $"prerecordedSchema:\n{JsonSerializer.Serialize(prerecordedSchema, JsonSerializeOptions.DefaultOptions)}");

        VerifyOneCallBackSet(nameof(TranscribeFileCallBack), callBack, prerecordedSchema);
        if (callBack != null)
            prerecordedSchema.CallBack = callBack;

        var uri = GetUri(_options, $"{UriSegments.LISTEN}");
        var result = await PostAsync<Stream, PrerecordedSchema, AsyncResponse>(uri, prerecordedSchema, source, cancellationToken, addons, headers);

        Log.Information("TranscribeFileCallBack", $"{uri} Succeeded");
        Log.Debug("TranscribeFileCallBack", $"result: {result}");
        Log.Verbose("PreRecordedClient.TranscribeFileCallBack", "LEAVE");

        return result;
    }

    /// <summary>
    /// Transcribe a file by providing a url and a CallBack
    /// </summary>
    /// <param name="source">Url to the file that is to be transcribed <see cref="UrlSource"/></param>
    /// <param name="callBack">CallBack url</param>    
    /// <param name="prerecordedSchema">Options for the transcription<see cref="PrerecordedSchema"></param>
    /// <returns><see cref="AsyncResponse"/></returns>
    public async Task<AsyncResponse> TranscribeUrlCallBack(UrlSource source, string? callBack, PrerecordedSchema? prerecordedSchema, CancellationTokenSource? cancellationToken = default, Dictionary<string, string>? addons = null, Dictionary<string, string>? headers = null)
    {
        Log.Verbose("PreRecordedClient.TranscribeUrlCallBack", "ENTER");
        Log.Information("TranscribeUrlCallBack", $"source: {source}");
        Log.Information("TranscribeUrlCallBack", $"callBack: {callBack}");
        Log.Information("TranscribeUrlCallBack", $"prerecordedSchema:\n{JsonSerializer.Serialize(prerecordedSchema, JsonSerializeOptions.DefaultOptions)}");

        VerifyOneCallBackSet(nameof(TranscribeUrlCallBack), callBack, prerecordedSchema);

        if (callBack != null)
            prerecordedSchema.CallBack = callBack;

        var uri = GetUri(_options, $"{UriSegments.LISTEN}");
        var result = await PostAsync<UrlSource, PrerecordedSchema, AsyncResponse>(uri, prerecordedSchema, source, cancellationToken, addons, headers);

        Log.Information("TranscribeUrlCallBack", $"{uri} Succeeded");
        Log.Debug("TranscribeUrlCallBack", $"result: {result}");
        Log.Verbose("PreRecordedClient.TranscribeUrlCallBack", "LEAVE");

        return result;
    }
    #endregion

    #region CallbackChecks
    private void VerifyNoCallBack(string method, PrerecordedSchema? prerecordedSchema)
    {
        Log.Debug("VerifyNoCallBack", $"method: {method}");

        if (prerecordedSchema != null && prerecordedSchema.CallBack != null)
        {
            var exStr = $"CallBack cannot be provided as schema option to a synchronous transcription when calling {method}. Use {nameof(TranscribeFileCallBack)} or {nameof(TranscribeUrlCallBack)}";
            Log.Error("VerifyNoCallBack", $"Exception: {exStr}");
            throw new ArgumentException(exStr);
        }
    }

    private void VerifyOneCallBackSet(string method, string? callBack, PrerecordedSchema? prerecordedSchema)
    {
        Log.Debug("VerifyOneCallBackSet", $"method: {method}");

        if (prerecordedSchema.CallBack == null && callBack == null)
        {
            //check if no CallBack set in either callBack parameter or AnalyzeSchema
            var exStr = $"Either provide a CallBack url or set PreRecordedSchema.CallBack.  If no CallBack needed either {nameof(TranscribeUrl)} or {nameof(TranscribeFile)}";
            Log.Error("VerifyNoCallBack", $"Exception: {exStr}");
            throw new ArgumentException(exStr);
        }
        else if (!string.IsNullOrEmpty(prerecordedSchema.CallBack) && !string.IsNullOrEmpty(callBack))
        {
            //check that only one CallBack is set in either callBack parameter or AnalyzeSchema
            var exStr = "CallBack should be set in either the CallBack parameter or PreRecordedSchema.CallBack not in both.";
            Log.Error("VerifyNoCallBack", $"Exceptions: {exStr}");
            throw new ArgumentException(exStr);
        }
    }
    #endregion    
}
