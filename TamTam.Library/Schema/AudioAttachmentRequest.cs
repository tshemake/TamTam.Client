using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach audio to message.
    /// Must be the only attachment in message.
    /// </summary>
    public class AudioAttachmentRequest : AttachmentRequest
    {
        /// <summary>
        /// This is information you will recieve as soon as audio/video is uploaded.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public UploadedInfo Payload { get; set; }
    }
}
