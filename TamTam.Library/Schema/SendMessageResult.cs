using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class SendMessageResult
    {
        /// <summary>
        /// Message in chat.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public Message Message { get; set; }
    }
}
