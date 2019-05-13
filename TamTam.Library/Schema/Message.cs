using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Message in chat.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// User that sent this message.
        /// Can be null if message has been posted on behalf of a channel.
        /// </summary>
        [JsonProperty(PropertyName = "sender", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Sender Sender { get; set; }

        /// <summary>
        /// Message recipient.
        /// Could be user or chat.
        /// </summary>
        [JsonProperty(PropertyName = "recipient", Required = Required.Always)]
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Unix-time when message was created.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        [JsonConverter(typeof(UnixEpochWithMilisecondsConventer))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Forwarder or replied message.
        /// </summary>
        [JsonProperty(PropertyName = "link", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public LinkedMessage Link { get; set; }

        /// <summary>
        /// Body of created message.
        /// Text + attachments.
        /// Could be null if message contains only forwarded message.
        /// </summary>
        [JsonProperty(PropertyName = "body", Required = Required.Always)]
        public MessageBody Body { get; set; }

        /// <summary>
        /// Message staistics.
        /// Available only for channels in GET:/messages context.
        /// </summary>
        [JsonProperty(PropertyName = "stat", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MessageStat Stat { get; set; }
    }
}
