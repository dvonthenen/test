﻿// Copyright 2021-2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Clients.Live.v1;

internal readonly struct WebSocketMessage(byte[] message, WebSocketMessageType type)
{
    public ArraySegment<byte> Message { get; } = new ArraySegment<byte>(message);

    public WebSocketMessageType MessageType { get; } = type;
}
