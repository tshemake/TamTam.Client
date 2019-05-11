using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Buttons in messages.
    /// </summary>
    public class InlineKeyboardAttachment
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// Unique identifier of keyboard.
        /// </summary>
        [JsonProperty(PropertyName = "callback_id", Required = Required.Always)]
        public string CallbackId { get; set; }

        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public InlineKeyboardAttachmentPayload Payload { get; set; }
    }
}
