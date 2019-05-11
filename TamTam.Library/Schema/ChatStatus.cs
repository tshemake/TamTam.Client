using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Chat status for current bot.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ChatStatus
    {
        Unknown = 0,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "removed")]
        Removed,

        [EnumMember(Value = "left")]
        Left,

        [EnumMember(Value = "closed")]
        Closed,

        [EnumMember(Value = "suspended")]
        Suspended,
    }
}
