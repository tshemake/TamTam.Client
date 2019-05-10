using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class PhotoToken
    {
        /// <summary>
        /// Encoded information of uploaded image.
        /// </summary>
        [JsonProperty(PropertyName = "token", Required = Required.Always)]
        public string Token { get; set; }
    }
}
