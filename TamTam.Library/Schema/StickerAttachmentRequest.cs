using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach sticker.
    /// Must be the only attachment request in message.
    /// </summary>
    public class StickerAttachmentRequest : AttachmentRequest
    {
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public StickerAttachmentRequestPayload Payload { get; set; }
    }
}
