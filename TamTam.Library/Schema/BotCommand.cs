using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class BotCommand
    {
        /// <summary>
        /// Command name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [StringLength(64, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Optional command description.
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(128, MinimumLength = 1)]
        public string Description { get; set; }
    }
}
