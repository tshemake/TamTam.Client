using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Endpoint you should upload to your binaries.
    /// </summary>
    public class UploadEndpoint
    {
        /// <summary>
        /// URL to upload.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }
    }
}
