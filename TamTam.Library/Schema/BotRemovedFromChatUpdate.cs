using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will receive this update when bot has been removed from chat.
    /// </summary>
    public class BotRemovedFromChatUpdate : Update
    {
        /// <summary>
        /// Chat identifier bot removed from.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// User id who removed bot from chat.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }
    }
}
