using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// You will get this <see cref="Update"/> as soon as message is removed.
    /// </summary>
    public class MessageRemovedUpdate : Update
    {
        /// <summary>
        /// Identifier of removed message.
        /// </summary>
        [JsonProperty(PropertyName = "message_id", Required = Required.Always)]
        public long MessageId { get; set; }
    }
}
