using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// This is information you will recieve as soon as a file is uploaded.
    /// </summary>
    public class UploadedFileInfo
    {
        /// <summary>
        /// Unique file identifier.
        /// </summary>
        [JsonProperty(PropertyName = "fileId", Required = Required.Always)]
        public long FileId { get; set; }
    }
}
