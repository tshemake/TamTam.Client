using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Image attachment.
    /// </summary>
    public class PhotoAttachment : Attachment
    {
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public PhotoAttachmentPayload Payload { get; set; }
    }
}
