using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class UserIdsList
    {
        /// <summary>
        /// Generic schema representing message attachment.
        /// </summary>
        [JsonProperty(PropertyName = "user_ids", Required = Required.Always)]
        public object UserIds { get; set; }
    }
}
