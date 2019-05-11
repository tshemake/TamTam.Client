using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class InlineKeyboardAttachmentPayload
    {
        [JsonProperty(PropertyName = "buttons", Required = Required.Always)]
        public IReadOnlyCollection<IReadOnlyCollection<Button>> Buttons { get; set; }
    }
}
