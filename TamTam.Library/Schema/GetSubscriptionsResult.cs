using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    /// <summary>
    /// List of all WebHook subscriptions.
    /// </summary>
    public class GetSubscriptionsResult
    {
        /// <summary>
        /// Current suscriptions.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptions", Required = Required.Always)]
        public IReadOnlyCollection<Subscription> Subscriptions { get; set; }
    }
}
