using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Object sent to bot when user presses button.
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// Unix-time when user pressed the button.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }

        /// <summary>
        /// Current keyboard identifier.
        /// </summary>
        [JsonProperty(PropertyName = "callback_id", Required = Required.Always)]
        public string CallbackId { get; set; }

        /// <summary>
        /// Button payload.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public string Payload { get; set; }

        /// <summary>
        /// User pressed the button.
        /// </summary>
        [JsonProperty(PropertyName = "user", Required = Required.Always)]
        public User User { get; set; }
    }
}
