using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will get this <see cref="Update"/> as soon as message is edited.
    /// </summary>
    public class MessageEditedUpdate : Update
    {
        /// <summary>
        /// Edited message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public Message Message { get; set; }
    }
}
