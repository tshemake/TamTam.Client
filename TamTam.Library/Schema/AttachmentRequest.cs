using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach some data to message.
    /// </summary>
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    public class AttachmentRequest
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public AttachmentRequestType Type { get; set; }
    }
}
