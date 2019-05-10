using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Simple response to request.
    /// </summary>
    public class SimpleQueryResult
    {
        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>true</term>  
        /// <description>If request was successful</description>
        /// </item>
        /// <item>
        /// <term>false</term>  
        /// <description>Otherwise</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
