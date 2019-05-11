using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// List of all updates in chats your bot participated in.
    /// </summary>
    public class UpdateList
    {
        /// <summary>
        /// Page of updates.
        /// </summary>
        [JsonProperty(PropertyName = "updates", Required = Required.Always)]
        public IReadOnlyCollection<Update> Updates { get; set; }

        /// <summary>
        /// Pointer to the next data page.
        /// </summary>
        [JsonProperty(PropertyName = "marker", Required = Required.AllowNull)]
        public long? Marker { get; set; }
    }
}
