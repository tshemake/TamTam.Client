using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Send this object when your bot wants to react to when a button is pressed.
    /// </summary>
    public class CallbackAnswer
    {
        [JsonProperty(PropertyName = "user_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        /// <summary>
        /// Fill this if you want to modify current message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public NewMessageBody Message { get; set; }

        /// <summary>
        /// Fill this if you just want to send one-time notification to user.
        /// </summary>
        [JsonProperty(PropertyName = "notification", Required = Required.AllowNull)]
        public string Notification { get; set; }
    }
}
