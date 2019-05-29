using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// New message recepient.
    /// Could be user or chat.
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Chat identifier.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Default)]
        public long? ChatId { get; set; }

        /// <summary>
        /// Chat type.
        /// </summary>
        [JsonProperty(PropertyName = "chat_type", Required = Required.Always)]
        public ChatType ChatType { get; set; }

        /// <summary>
        /// User identifier, if message was sent to user.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Default)]
        public long? UserId { get; set; }
    }
}
