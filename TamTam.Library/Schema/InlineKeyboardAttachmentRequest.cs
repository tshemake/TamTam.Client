using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach keyboard to message.
    /// </summary>
    public class InlineKeyboardAttachmentRequest : AttachmentRequest
    {
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public InlineKeyboardAttachmentRequestPayload Payload { get; set; }
    }
}
