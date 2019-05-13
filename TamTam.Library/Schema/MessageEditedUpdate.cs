using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will get this <see cref="Update"/> as soon as message is edited.
    /// </summary>
    public class MessageEditedUpdate
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
        /// Edited message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.AllowNull)]
        public Message Message { get; set; }
    }
}
