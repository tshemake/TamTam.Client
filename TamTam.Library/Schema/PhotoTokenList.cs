using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// This is information you will recieve as soon as an image uploaded.
    /// </summary>
    public class PhotoTokenList
    {
        [JsonProperty(PropertyName = "photos", Required = Required.Always)]
        public IReadOnlyDictionary<string, PhotoToken> Photos { get; set; }
    }
}
