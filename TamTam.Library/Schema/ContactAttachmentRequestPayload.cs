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
        [JsonProperty(PropertyName = "name", Required = Required.AllowNull)]
        public string Name { get; set; }

        /// <summary>
        /// Contact identifier.
        /// </summary>
        [JsonProperty(PropertyName = "contactId", Required = Required.AllowNull)]
        public long? ContactId { get; set; }

        /// <summary>
        /// Full information about contact in VCF format.
        /// </summary>
        [JsonProperty(PropertyName = "vcfInfo", Required = Required.AllowNull)]
        public string VcfInfo { get; set; }

        /// <summary>
        /// Contact phone in VCF format.
        /// </summary>
        [JsonProperty(PropertyName = "vcfPhone", Required = Required.AllowNull)]
        public string VcfPhone { get; set; }
    }
}
