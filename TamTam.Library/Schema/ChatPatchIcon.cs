using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ChatPatchIcon
    {
        /// <summary>
        /// Any external image URL you want to attach.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Token of any existing attachment.
        /// </summary>
        [JsonProperty(PropertyName = "token", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        /// <summary>
        /// Tokens were obtained after uploading images.
        /// </summary>
        [JsonProperty(PropertyName = "photos", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyDictionary<string, PhotoToken> Photos { get; set; }
    }
}
