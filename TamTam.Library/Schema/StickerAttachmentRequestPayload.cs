using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class StickerAttachmentRequestPayload
    {
        /// <summary>
        /// Sticker code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public string Code { get; set; }
    }
}
