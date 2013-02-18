using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class NotificationParams
    {
        [JsonProperty("data")]
        public JObject Data { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }
    }
}