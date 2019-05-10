using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class Photo
    {
        /// <summary>
        /// Any external image URL you want to attach.
        /// </summary>
        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Token of any existing attachment.
        /// </summary>
        [JsonProperty(PropertyName = "token", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Token { get; set; }
    }
}
