using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ChatMembersList
    {
        /// <summary>
        /// Participants in chat with time of last activity.
        /// Visible only for chat admins.
        /// </summary>
        [JsonProperty(PropertyName = "members", Required = Required.Always)]
        public IReadOnlyCollection<ChatMember> Members { get; set; }

        /// <summary>
        /// Pointer to the next data page.
        /// </summary>
        [JsonProperty(PropertyName = "marker", Required = Required.Default)]
        public long? Marker { get; set; }
    }
}
