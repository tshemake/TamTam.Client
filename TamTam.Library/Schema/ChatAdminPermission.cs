using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Chat admin permissions.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ChatAdminPermission
    {
        Unknown = 0,

        [EnumMember(Value = "read_all_messages")]
        ReadAllMessages,

        [EnumMember(Value = "add_remove_members")]
        AddRemoveMembers,

        [EnumMember(Value = "add_admins")]
        AddAdmins,

        [EnumMember(Value = "change_chat_info")]
        ChangeChatInfo,

        [EnumMember(Value = "pin_message")]
        PinMessage,

        [EnumMember(Value = "write")]
        Write,
    }
}
