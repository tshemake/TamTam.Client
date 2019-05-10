using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Type of linked message.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum MessageLinkType
    {
        Unknown = 0,

        [EnumMember(Value = "forward")]
        Forward,

        [EnumMember(Value = "reply")]
        Reply,
    }
}
