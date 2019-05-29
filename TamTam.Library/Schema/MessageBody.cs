using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Schema representing body of message.
    /// </summary>
    public class MessageBody
    {
        /// <summary>
        /// Unique identifier of message.
        /// </summary>
        [JsonProperty(PropertyName = "mid", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Mid { get; set; }

        /// <summary>
        /// Sequence identifier of message in chat.
        /// </summary>
        [JsonProperty(PropertyName = "seq", Required = Required.Always)]
        public long Seq { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        [JsonProperty(PropertyName = "text", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Message attachments.
        /// Could be one of <see cref="Attachment"/> type.
        /// </summary>
        [JsonProperty(PropertyName = "attachments", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyCollection<Attachment> Attachments { get; set; }

        /// <summary>
        /// In case this message is repled to,
        /// it is the unique identifier of the replied message.
        /// </summary>
        [JsonProperty(PropertyName = "reply_to", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete]
        public string ReplyTo { get; set; }
    }
}
