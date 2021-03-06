﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// After pressing this type of button client sends
    /// new message with attachment of curent user contact.
    /// </summary>
    public class RequestContactButton : Button
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public override ButtonType Type => ButtonType.RequestContact;
    }
}
