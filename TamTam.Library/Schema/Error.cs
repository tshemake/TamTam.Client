using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Server returns this if there was an exception to your request.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error.
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorInfo { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public string Code { get; set; }

        /// <summary>
        /// Human-readable description.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public string Message { get; set; }
    }
}
