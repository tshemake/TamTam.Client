using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach some data to message.
    /// </summary>
    public class PhotoAttachmentRequest
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// Request to attach image.
        /// All fields are mutually exclusive.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public PhotoAttachmentRequestPayload Payload { get; set; }
    }
}
