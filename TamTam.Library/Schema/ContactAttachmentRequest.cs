using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to attach contact card to message.
    /// Must be the only attachment in message.
    /// </summary>
    public class ContactAttachmentRequest : AttachmentRequest
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public override AttachmentRequestType Type => AttachmentRequestType.Contact;

        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public ContactAttachmentRequestPayload Payload { get; set; }
    }
}
