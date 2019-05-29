using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class MediaAttachmentPayload
    {
        /// <summary>
        /// Media attachment URL.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Url { get; set; }

        /// <summary>
        /// Identifier of media attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public long Id { get; set; }
    }
}
