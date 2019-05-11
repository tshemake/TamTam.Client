using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class FileAttachmentPayload
    {
        /// <summary>
        /// Media attachment URL.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }

        /// <summary>
        /// Identifier of uploaded file.
        /// </summary>
        [JsonProperty(PropertyName = "fileId", Required = Required.Always)]
        public long FileId { get; set; }
    }
}
