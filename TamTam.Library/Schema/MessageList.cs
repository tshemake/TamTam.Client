using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Paginated list of messages.
    /// </summary>
    public class MessageList
    {
        /// <summary>
        /// List of messages.
        /// </summary>
        [JsonProperty(PropertyName = "messages", Required = Required.AllowNull)]
        public IReadOnlyCollection<Message> Messages { get; set; }
    }
}
