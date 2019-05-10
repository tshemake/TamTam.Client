using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Schema to describe WebHook subscription.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// WebHook URL.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }

        /// <summary>
        /// Unix-time when subscription was created.
        /// </summary>
        [JsonProperty(PropertyName = "time", Required = Required.Always)]
        public long Time { get; set; }

        /// <summary>
        /// Update types bot subscribed for.
        /// </summary>
        [JsonProperty(PropertyName = "update_types")]
        public IReadOnlyCollection<UpdateType> UpdateTypes { get; set; }

        [JsonProperty(PropertyName = "version")]
        [RegularExpression("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}")]
        public string Version { get; set; }
    }
}
