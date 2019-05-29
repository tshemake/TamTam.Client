using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(AllowEmptyStrings = true)]
        public string Url { get; set; }

        /// <summary>
        /// List of update types your bot want to receive.
        /// See <see cref="Update"/> object for a complete list of types.
        /// </summary>
        [JsonProperty(PropertyName = "update_types", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyCollection<UpdateType> UpdateTypes { get; set; }

        /// <summary>
        /// Version of API.
        /// Affects model representation.
        /// </summary>
        [JsonProperty(PropertyName = "version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }
    }
}
