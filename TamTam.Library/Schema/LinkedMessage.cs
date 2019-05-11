using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Forwarder or replied message.
    /// </summary>
    public class LinkedMessage
    {
        /// <summary>
        /// Type of linked message.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public MessageLinkType Type { get; set; }

        /// <summary>
        /// User sent this message.
        /// </summary>
        [JsonProperty(PropertyName = "sender", Required = Required.Always)]
        public Sender Sender { get; set; }

        /// <summary>
        /// Chat where message was originally posted.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// Schema representing body of message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public MessageBody Message { get; set; }
    }
}
