using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// This is information you will recieve as soon as audio/video is uploaded.
    /// </summary>
    public class UploadedInfo
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public long Id { get; set; }
    }
}
