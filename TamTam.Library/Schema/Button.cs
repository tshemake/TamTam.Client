using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    public class Button
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public virtual ButtonType Type { get; set; }

        /// <summary>
        /// Visible text of button.
        /// </summary>
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(128)]
        public string Text { get; set; }
    }
}
