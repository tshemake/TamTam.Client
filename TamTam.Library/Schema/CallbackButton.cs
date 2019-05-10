using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// After pressing this type of button client
    /// sends to server payload it contains.
    /// </summary>
    public class CallbackButton : Button
    {
        /// <summary>
        /// Button payload.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        [MaxLength(1024)]
        public string Payload { get; set; }

        /// <summary>
        /// Intent of button. Affects clients representation.
        /// </summary>
        [JsonProperty(PropertyName = "intent")]
        public Intent Intent { get; set; } = Intent.Default;
    }
}
