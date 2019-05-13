using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Bot gets this type of update as soon as user pressed Start button.
    /// </summary>
    public class BotStartedUpdate
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
        /// Dialog identifier where event has occurred.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// User pressed the 'Start' button.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }
    }
}
