using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will get this <see cref="Update"/> as soon as message is created.
    /// </summary>
    public class MessageCreatedUpdate
    {
        [JsonProperty(PropertyName = "update_type", Required = Required.Always)]
        public string UpdateType { get; set; }

        /// <summary>
        /// Unix-time when event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }

        /// <summary>
        /// Newly created message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.AllowNull)]
        public Message Message { get; set; }
    }
}
