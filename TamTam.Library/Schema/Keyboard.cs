using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Keyboard is two-dimension array of buttons.
    /// </summary>
    public class Keyboard
    {
        [JsonProperty(PropertyName = "buttons", Required = Required.Always)]
        public IReadOnlyCollection<IReadOnlyCollection<Button>> Buttons { get; set; }
    }
}
