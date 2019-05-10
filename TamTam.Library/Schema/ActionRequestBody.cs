using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ActionRequestBody
    {
        /// <summary>
        /// Different actions to send to chat members.
        /// </summary>
        [JsonProperty(PropertyName = "action", Required = Required.Always)]
        public SenderAction Action { get; set; }
    }
}
