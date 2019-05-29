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
    public enum AttachmentRequestType
    {
        Unknown = 0,

        [EnumMember(Value = "image")]
        [ObjectType(typeof(PhotoAttachmentRequest))]
        Image,

        [EnumMember(Value = "video")]
        [ObjectType(typeof(VideoAttachmentRequest))]
        Video,

        [EnumMember(Value = "audio")]
        [ObjectType(typeof(AudioAttachmentRequest))]
        Audio,

        [EnumMember(Value = "file")]
        [ObjectType(typeof(FileAttachmentRequest))]
        File,

        [EnumMember(Value = "contact")]
        [ObjectType(typeof(ContactAttachmentRequest))]
        Contact,

        [EnumMember(Value = "sticker")]
        [ObjectType(typeof(StickerAttachmentRequest))]
        Sticker,

        [EnumMember(Value = "inline_keyboard")]
        [ObjectType(typeof(InlineKeyboardAttachmentRequest))]
        InlineKeyboard,

        [EnumMember(Value = "location")]
        [ObjectType(typeof(LocationAttachmentRequest))]
        Location,
    }
}
