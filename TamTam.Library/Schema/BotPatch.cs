using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class BotPatch
    {
        /// <summary>
        /// Visible name of bot.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(64, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Bot unique identifier.
        /// It can be any string 4-64 characters long containing any digit,
        /// letter or special symbols: "-" or "_". It must starts with a letter.
        /// </summary>
        [JsonProperty(PropertyName = "username", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(64, MinimumLength = 4)]
        [RegularExpression("[a-z]+[a-z0-9-_]*")]
        public string UserName { get; set; }

        /// <summary>
        /// Bot description up to 16k characters long.
        /// </summary>
        [JsonProperty(PropertyName = "description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(16000, MinimumLength = 1)]
        public string Description { get; set; }

        /// <summary>
        /// Commands supported by bot.
        /// Pass empty list if you want to remove commands.
        /// </summary>
        [JsonProperty(PropertyName = "commands", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyCollection<BotCommand> Commands { get; set; }

        /// <summary>
        /// Request to set bot photo.
        /// </summary>
        [JsonProperty(PropertyName = "photo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Photo Photo { get; set; }
    }
}
