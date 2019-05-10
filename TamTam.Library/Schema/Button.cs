using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class Button
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// Visible text of button.
        /// </summary>
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        [MaxLength(128)]
        public string Text { get; set; }
    }
}
