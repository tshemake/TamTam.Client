using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will get this <see cref="Update"/> as soon as user presses button.
    /// </summary>
    public class MessageCallbackUpdate
    {
        [JsonProperty(PropertyName = "update_type", Required = Required.Always)]
        public string UpdateType { get; set; }

        /// <summary>
        /// Unix-time when event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }

        [JsonProperty(PropertyName = "callback", Required = Required.Always)]
        public Callback Callback { get; set; }

        /// <summary>
        /// Original message containing inline keyboard.
        /// Can be null in case it had been deleted by the moment a bot got this update.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.AllowNull)]
        public Message Message { get; set; }
    }
}
