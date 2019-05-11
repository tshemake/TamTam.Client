using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Type of file uploading.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum UploadType
    {
        Unknown = 0,

        [EnumMember(Value = "photo")]
        Photo,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "file")]
        File,
    }
}
