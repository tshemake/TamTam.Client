using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Different actions to send to chat members.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum SenderAction
    {
        Unknown = 0,

        [EnumMember(Value = "typing_on")]
        TypingOn,

        [EnumMember(Value = "typing_off")]
        TypingOff,

        [EnumMember(Value = "sending_photo")]
        SendingPhoto,

        [EnumMember(Value = "sending_video")]
        SendingVideo,

        [EnumMember(Value = "sending_audio")]
        SendingAudio,

        [EnumMember(Value = "mark_seen")]
        MarkSeen,
    }
}
