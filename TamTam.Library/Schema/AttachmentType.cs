﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TamTam.Bot.Attributes;

namespace TamTam.Bot.Schema
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum AttachmentType
    {
        Unknown = 0,

        [EnumMember(Value = "image")]
        [ObjectType(typeof(PhotoAttachment))]
        Image,

        [EnumMember(Value = "video")]
        [ObjectType(typeof(VideoAttachment))]
        Video,

        [EnumMember(Value = "audio")]
        [ObjectType(typeof(AudioAttachment))]
        Audio,

        [EnumMember(Value = "file")]
        [ObjectType(typeof(FileAttachment))]
        File,

        [EnumMember(Value = "contact")]
        [ObjectType(typeof(ContactAttachment))]
        Contact,

        [EnumMember(Value = "sticker")]
        [ObjectType(typeof(StickerAttachment))]
        Sticker,

        [EnumMember(Value = "share")]
        [ObjectType(typeof(ShareAttachment))]
        Share,

        [EnumMember(Value = "location")]
        [ObjectType(typeof(LocationAttachment))]
        Location,

        [EnumMember(Value = "inline_keyboard")]
        [ObjectType(typeof(InlineKeyboardAttachment))]
        InlineKeyboard,
    }
}
