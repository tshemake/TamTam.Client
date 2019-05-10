using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum UpdateType
    {
        Unknown = 0,

        [EnumMember(Value = "message_created")]
        MessageCreated,

        [EnumMember(Value = "bot_started")]
        BotStarted,
    }
}
