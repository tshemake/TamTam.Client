using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Request to set up WebHook subscription.
    /// </summary>
    public class SubscriptionRequestBody
    {
        /// <summary>
        /// URL of HTTP(S)-endpoint of your bot.
        /// </summary>
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }

        /// <summary>
        /// List of update types your bot want to receive.
        /// See <see cref="Update"/> object for a complete list of types.
        /// </summary>
        [JsonProperty(PropertyName = "update_types", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReadOnlyCollection<UpdateType> UpdateTypes { get; set; }

        /// <summary>
        /// Version of API.
        /// Affects model representation.
        /// </summary>
        [JsonProperty(PropertyName = "version", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Version { get; set; }
    }
}
