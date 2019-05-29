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
    public enum ButtonType
    {
        Unknown = 0,

        [EnumMember(Value = "callback")]
        [ObjectType(typeof(CallbackButton))]
        Callback,

        [EnumMember(Value = "link")]
        [ObjectType(typeof(LinkButton))]
        Link,

        [EnumMember(Value = "request_contact")]
        [ObjectType(typeof(RequestContactButton))]
        RequestContact,

        [EnumMember(Value = "request_geo_location")]
        [ObjectType(typeof(RequestGeoLocationButton))]
        RequestGeoLocation,
    }
}
