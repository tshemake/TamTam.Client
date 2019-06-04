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
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public override AttachmentRequestType Type => AttachmentRequestType.Audio;

        /// <summary>
        /// This is information you will recieve as soon as audio/video is uploaded.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public UploadedInfo Payload { get; set; }
    }
}
