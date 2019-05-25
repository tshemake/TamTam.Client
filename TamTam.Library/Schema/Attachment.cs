using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Generic schema representing message attachment.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Generic schema representing message attachment.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public AttachmentType Type { get; set; }
    }
}
