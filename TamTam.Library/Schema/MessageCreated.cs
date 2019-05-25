using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class MessageCreated : Update
    {
        /// <summary>
        /// Original message containing inline keyboard.
        /// Can be null in case it had been deleted by the moment a bot got this update.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public Message Message { get; set; }
    }
}
