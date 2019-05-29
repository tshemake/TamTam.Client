using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class User
    {
        /// <summary>
        /// Users identifier.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }

        /// <summary>
        /// Users visible name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Unique public user name. 
        /// Can be null if user is not accessible or it is not set.
        /// </summary>
        [JsonProperty(PropertyName = "username", Required = Required.Default)]
        public string UserName { get; set; }
    }
}
