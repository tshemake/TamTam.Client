using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Intent of button.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Intent
    {
        [EnumMember(Value = "default")]
        Default = 0,

        [EnumMember(Value = "positive")]
        Positive,

        [EnumMember(Value = "negative")]
        Negative,
    }
}
