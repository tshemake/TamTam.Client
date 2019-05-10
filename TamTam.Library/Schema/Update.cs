using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Update object repsesents different types of events
    /// that happened in chat. See its inheritors.
    /// </summary>
    public class Update
    {
        [JsonProperty(PropertyName = "update_type", Required = Required.Always)]
        public UpdateType UpdateType { get; set; }

        /// <summary>
        /// Unix-time when event has occured.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }
    }
}
