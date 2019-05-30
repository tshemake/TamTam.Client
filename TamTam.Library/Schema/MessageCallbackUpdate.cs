using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will get this <see cref="Update"/> as soon as user presses button.
    /// </summary>
    public class MessageCallbackUpdate : Update
    {
        [JsonProperty(PropertyName = "callback", Required = Required.Always)]
        public Callback Callback { get; set; }

        /// <summary>
        /// Original message containing inline keyboard.
        /// Can be null in case it had been deleted by the moment a bot got this update.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Default)]
        public Message Message { get; set; }
    }
}
