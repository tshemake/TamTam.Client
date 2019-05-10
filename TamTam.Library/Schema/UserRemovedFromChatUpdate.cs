using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will receive this update when user has been removed
    /// from chat where bot is administrator.
    /// </summary>
    public class UserRemovedFromChatUpdate
    {
        [JsonProperty(PropertyName = "update_type", Required = Required.Always)]
        public string UpdateType { get; set; }

        /// <summary>
        /// Unix-time when event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }

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
