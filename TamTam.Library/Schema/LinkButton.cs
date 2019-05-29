using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// After pressing this type of button user follows the link it contains.
    /// </summary>
    public class LinkButton : Button
    {
        /// <summary>
        /// Button payload.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(256)]
        public string Url { get; set; }
    }
}
