using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach file to message.
    /// Must be the only attachment in message.
    /// </summary>
    public class FileAttachmentRequest : AttachmentRequest
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public override AttachmentRequestType Type => AttachmentRequestType.File;

        /// <summary>
        /// This is information you will recieve as soon as a file is uploaded.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public UploadedFileInfo Payload { get; set; }
    }
}
