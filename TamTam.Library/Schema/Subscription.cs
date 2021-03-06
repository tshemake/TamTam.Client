﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

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
        [Required(AllowEmptyStrings = true)]
        public string Url { get; set; }

        /// <summary>
        /// Unix-time when subscription was created.
        /// </summary>
        [JsonProperty(PropertyName = "time", Required = Required.Always)]
        [JsonConverter(typeof(UnixEpochWithMilisecondsConventer))]
        public DateTime Time { get; set; }

        /// <summary>
        /// Update types bot subscribed for.
        /// </summary>
        [JsonProperty(PropertyName = "update_types", Required = Required.Default)]
        public IReadOnlyCollection<UpdateType> UpdateTypes { get; set; }

        [JsonProperty(PropertyName = "version", Required = Required.Default)]
        [RegularExpression("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}")]
        public string Version { get; set; }
    }
}
