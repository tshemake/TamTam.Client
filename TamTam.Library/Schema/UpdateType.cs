using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TamTam.Bot.Attributes;

namespace TamTam.Bot.Schema
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum UpdateType
    {
        Unknown = 0,

        [EnumMember(Value = "message_callback")]
        [ObjectType(typeof(MessageCallbackUpdate))]
        MessageCallback,

        [EnumMember(Value = "message_created")]
        [ObjectType(typeof(MessageCreatedUpdate))]
        MessageCreated,

        [EnumMember(Value = "message_removed")]
        [ObjectType(typeof(MessageRemovedUpdate))]
        MessageRemoved,

        [EnumMember(Value = "message_edited")]
        [ObjectType(typeof(MessageEditedUpdate))]
        MessageEdited,

        [EnumMember(Value = "bot_added")]
        [ObjectType(typeof(BotAddedToChatUpdate))]
        BotAdded,

        [EnumMember(Value = "bot_removed")]
        [ObjectType(typeof(BotRemovedFromChatUpdate))]
        BotRemoved,

        [EnumMember(Value = "user_added")]
        [ObjectType(typeof(UserAddedToChatUpdate))]
        UserAdded,

        [EnumMember(Value = "user_removed")]
        [ObjectType(typeof(UserRemovedFromChatUpdate))]
        UserRemoved,

        [EnumMember(Value = "bot_started")]
        [ObjectType(typeof(BotStartedUpdate))]
        BotStarted,

        [EnumMember(Value = "chat_title_changed")]
        [ObjectType(typeof(ChatTitleChangedUpdate))]
        ChatTitleChanged,
    }
}
