using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will receive this update when user has been removed
    /// from chat where bot is administrator.
    /// </summary>
    public class UserRemovedFromChatUpdate : Update
    {
        /// <summary>
        /// Chat identifier where event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// User removed from chat.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }

        /// <summary>
        /// Administrator who removed user from chat.
        /// </summary>
        [JsonProperty(PropertyName = "admin_id", Required = Required.Always)]
        public long AdminId { get; set; }
    }
}
