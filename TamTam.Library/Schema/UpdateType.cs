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

        [EnumMember(Value = "message_callback")]
        MessageCallback,

        [EnumMember(Value = "message_created")]
        MessageCreated,

        [EnumMember(Value = "message_removed")]
        MessageRemoved,

        [EnumMember(Value = "message_edited")]
        MessageEdited,

        [EnumMember(Value = "bot_added")]
        BotAdded,

        [EnumMember(Value = "bot_removed")]
        BotRemoved,

        [EnumMember(Value = "user_added")]
        UserAdded,

        [EnumMember(Value = "user_removed")]
        UserRemoved,

        [EnumMember(Value = "bot_started")]
        BotStarted,

        [EnumMember(Value = "chat_title_changed")]
        ChatTitleChanged,
    }
}
