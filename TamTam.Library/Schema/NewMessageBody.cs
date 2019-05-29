using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class NewMessageBody
    {
        /// <summary>
        /// Message text.
        /// </summary>
        [JsonProperty(PropertyName = "text", Required = Required.Default)]
        [MaxLength(4000)]
        public string Text { get; set; }

        /// <summary>
        /// Single message attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Use attachments property instead.")]
        public Attachment Attachment { get; set; }

        /// <summary>
        /// Message attachments.
        /// See <see cref="AttachmentRequest"/> and it's inheritors for full information.
        /// </summary>
        [JsonProperty(PropertyName = "attachments", Required = Required.Default)]
        public IReadOnlyCollection<AttachmentRequest> Attachments { get; set; }

        /// <summary>
        /// Link to Message.
        /// </summary>
        [JsonProperty(PropertyName = "link", Required = Required.Default)]
        public NewMessageLink Link { get; set; }

        /// <summary>
        /// If false, chat participants wouldn't be notified.
        /// </summary>
        [JsonProperty(PropertyName = "notify", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Notify { get; set; } = true;
    }
}
