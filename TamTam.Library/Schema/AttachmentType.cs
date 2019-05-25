using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum AttachmentType
    {
        Unknown = 0,

        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "contact")]
        Contact,

        [EnumMember(Value = "sticker")]
        Sticker,

        [EnumMember(Value = "share")]
        Share,

        [EnumMember(Value = "location")]
        Location,

        [EnumMember(Value = "inline_keyboard")]
        InlineKeyboard,
    }
}
