using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Generic schema representing message attachment.
    /// </summary>
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    public class Attachment
    {
        /// <summary>
        /// Generic schema representing message attachment.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public AttachmentType Type { get; set; }
    }
}
