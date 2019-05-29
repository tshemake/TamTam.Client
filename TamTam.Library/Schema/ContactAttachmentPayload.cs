using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ContactAttachmentPayload
    {
        /// <summary>
        /// User info in VCF format.
        /// </summary>
        [JsonProperty(PropertyName = "vcfInfo", Required = Required.Default)]
        public string VcfInfo { get; set; }

        /// <summary>
        /// User info.
        /// </summary>
        [JsonProperty(PropertyName = "tamInfo", Required = Required.Default)]
        public User TamInfo { get; set; }
    }
}
