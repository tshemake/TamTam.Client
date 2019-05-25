using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Update object repsesents different types of events
    /// that happened in chat. See its inheritors.
    /// </summary>
    [JsonConverter(typeof(UpdateTypeConverter))]
    public class Update
    {
        [JsonProperty(PropertyName = "chat_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ChatId { get; set; }

        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        [JsonProperty(PropertyName = "update_type", Required = Required.Always)]
        public UpdateType UpdateType { get; set; }

        /// <summary>
        /// Unix-time when event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        [JsonConverter(typeof(UnixEpochWithMilisecondsConventer))]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "callback", NullValueHandling = NullValueHandling.Ignore)]
        public Callback Callback { get; set; }
    }
}
