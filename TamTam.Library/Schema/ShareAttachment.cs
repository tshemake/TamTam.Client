using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Generic schema representing message attachment.
    /// </summary>
    public class ShareAttachment : Attachment
    {
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public AttachmentPayload Payload { get; set; }
    }
}
