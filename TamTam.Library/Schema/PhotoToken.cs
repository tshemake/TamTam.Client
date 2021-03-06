﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class PhotoToken
    {
        /// <summary>
        /// Encoded information of uploaded image.
        /// </summary>
        [JsonProperty(PropertyName = "token", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]

        public string Token { get; set; }
    }
}
