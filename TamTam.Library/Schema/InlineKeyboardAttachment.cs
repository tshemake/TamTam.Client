using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Buttons in messages.
    /// </summary>
    public class InlineKeyboardAttachment : Attachment
    {
        /// <summary>
        /// Unique identifier of keyboard.
        /// </summary>
        [JsonProperty(PropertyName = "callback_id", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string CallbackId { get; set; }

        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public InlineKeyboardAttachmentPayload Payload { get; set; }
    }
}
