using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Generic schema representing message attachment.
    /// </summary>
    public class ContactAttachment
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public JsonContainerAttribute Payload { get; set; }
    }
}
