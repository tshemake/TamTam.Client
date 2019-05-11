using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Icon of chat.
    /// </summary>
    public class ChatIcon
    {
        /// <summary>
        /// URL of image.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }
    }
}
