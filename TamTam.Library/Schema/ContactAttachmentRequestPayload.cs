using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ContactAttachmentRequestPayload
    {
        /// <summary>
        /// Contact name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Contact identifier.
        /// </summary>
        [JsonProperty(PropertyName = "contactId", Required = Required.Default)]
        public long? ContactId { get; set; }

        /// <summary>
        /// Full information about contact in VCF format.
        /// </summary>
        [JsonProperty(PropertyName = "vcfInfo", Required = Required.Default)]
        public string VcfInfo { get; set; }

        /// <summary>
        /// Contact phone in VCF format.
        /// </summary>
        [JsonProperty(PropertyName = "vcfPhone", Required = Required.Default)]
        public string VcfPhone { get; set; }
    }
}
