using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Bot gets this type of update as soon as title has been changed in chat.
    /// </summary>
    public class ChatTitleChangedUpdate : Update
    {
        /// <summary>
        /// Chat identifier where event has occurred.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// User who changed title.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }

        /// <summary>
        /// New title.
        /// </summary>
        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; }
    }
}
