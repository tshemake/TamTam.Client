using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach video to message.
    /// </summary>
    public class VideoAttachmentRequest
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// This is information you will recieve as soon as audio/video is uploaded.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public UploadedInfo Payload { get; set; }
    }
}
