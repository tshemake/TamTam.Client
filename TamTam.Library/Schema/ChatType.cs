using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Type of chat.
    /// Dialog (one-on-one), chat or channel.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ChatType
    {
        Unknown = 0,

        [EnumMember(Value = "dialog")]
        Dialog,

        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "channel")]
        Channel,
    }
}
