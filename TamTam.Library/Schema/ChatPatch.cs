using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ChatPatch
    {
        [JsonProperty(PropertyName = "icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ChatPatchIcon Icon { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }
}
