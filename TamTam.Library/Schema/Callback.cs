﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using TamTam.Bot.Converters;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Object sent to bot when user presses button.
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// Unix-time when user pressed the button.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        [JsonConverter(typeof(UnixEpochWithMilisecondsConventer))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Current keyboard identifier.
        /// </summary>
        [JsonProperty(PropertyName = "callback_id", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string CallbackId { get; set; }

        /// <summary>
        /// Button payload.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Payload { get; set; }

        /// <summary>
        /// User pressed the button.
        /// </summary>
        [JsonProperty(PropertyName = "user", Required = Required.Always)]
        public User User { get; set; }
    }
}
