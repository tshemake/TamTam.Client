﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// After pressing this type of button client sends 
    /// new message with attachment of current user geo location.
    /// </summary>
    public class RequestGeoLocationButton : Button
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public override ButtonType Type => ButtonType.RequestGeoLocation;

        /// <summary>
        /// If true, sends location without asking user's confirmation.
        /// </summary>
        [JsonProperty(PropertyName = "quick", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Quick { get; set; } = false;
    }
}
