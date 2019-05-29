using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Generic schema representing message attachment.
    /// </summary>
    public class AudioAttachment : Attachment
    {
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public MediaAttachmentPayload Payload { get; set; }
    }
}
