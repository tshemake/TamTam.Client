using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach some data to message.
    /// </summary>
    public class AttachmentRequest
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public AttachmentRequestType Type { get; set; }
    }
}
