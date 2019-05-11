﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// Generic schema representing message attachment.
    /// </summary>
    public class LocationAttachment
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public double Longitude { get; set; }
    }
}
