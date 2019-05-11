using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class NewMessageLink
    {
        /// <summary>
        /// Type of message link.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public MessageLinkType Type { get; set; }

        /// <summary>
        /// Message identifier of original message.
        /// </summary>
        [JsonProperty(PropertyName = "mid", Required = Required.Always)]
        public string Mid { get; set; }
    }
}
