using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Bot gets this type of update as soon as user pressed Start button.
    /// </summary>
    public class BotStartedUpdate : Update
    {
        /// <summary>
        /// Dialog identifier where event has occurred.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// User pressed the 'Start' button.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }
    }
}
