using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will receive this update when user has been added 
    /// to chat where bot is administrator.
    /// </summary>
    public class UserAddedToChatUpdate
    {
        [JsonProperty(PropertyName = "update_type", Required = Required.Always)]
        public string UpdateType { get; set; }

        /// <summary>
        /// Unix-time when event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        [JsonConverter(typeof(UnixEpochWithMilisecondsConventer))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Chat identifier where event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// User added to chat.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }

        /// <summary>
        /// User who added user to chat.
        /// </summary>
        [JsonProperty(PropertyName = "inviter_id", Required = Required.Always)]
        public long InviterId { get; set; }
    }
}
