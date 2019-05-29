using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class PhotoAttachmentPayload
    {
        /// <summary>
        /// Unique identifier of this image.
        /// </summary>
        [JsonProperty(PropertyName = "photo_id", Required = Required.Always)]
        public long PhotoId { get; set; }

        [JsonProperty(PropertyName = "token", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Token { get; set; }

        /// <summary>
        /// Image URL.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Url { get; set; }
    }
}
