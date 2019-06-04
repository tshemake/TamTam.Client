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
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public override ButtonType Type => ButtonType.Callback;

        /// <summary>
        /// Button payload.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(1024)]
        public string Payload { get; set; }

        /// <summary>
        /// Intent of button. Affects clients representation.
        /// </summary>
        [JsonProperty(PropertyName = "intent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Intent Intent { get; set; } = Intent.Default;
    }
}
