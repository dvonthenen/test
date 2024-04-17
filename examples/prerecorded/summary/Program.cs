// Copyright 2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

using System.Text.Json;

using Deepgram.Models.PreRecorded.v1;

namespace PreRecorded
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize Library with default logging
            // Normal logging is "Info" level
            Library.Initialize();

            // JSON options
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            // Set "DEEPGRAM_API_KEY" environment variable to your Deepgram API Key
            var deepgramClient = new PreRecordedClient();

            // check to see if the file exists
            if (!File.Exists(@"CallCenterPhoneCall.mp3"))
            {
                Console.WriteLine("Error: File 'CallCenterPhoneCall.mp3' not found.");
                return;
            }

            var audioData = File.ReadAllBytes(@"CallCenterPhoneCall.mp3");
            var response = await deepgramClient.TranscribeFile(
                audioData,
                new PrerecordedSchema()
                {
                    Model = "nova-2",
                    Punctuate = true,
                    Summarize = "v2",
                });

            Console.WriteLine(JsonSerializer.Serialize(response, options));
            Console.ReadKey();

            // Teardown Library
            Library.Terminate();
        }
    }
}