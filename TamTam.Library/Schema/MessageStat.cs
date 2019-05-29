using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Message statistics.
    /// </summary>
    public class MessageStat
    {
        [JsonProperty(PropertyName = "views", Required = Required.Always)]
        public int Views { get; set; }
    }
}
