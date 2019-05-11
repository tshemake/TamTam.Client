using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ChatList
    {
        /// <summary>
        /// List of requested chats.
        /// </summary>
        [JsonProperty(PropertyName = "chats", Required = Required.Always)]
        public IReadOnlyCollection<Chat> Chats { get; set; }

        /// <summary>
        /// Reference to the next page of requested chats.
        /// </summary>
        [JsonProperty(PropertyName = "marker", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Marker { get; set; }
    }
}
