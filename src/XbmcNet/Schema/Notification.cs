using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class Notification
    {
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public NotificationParams Params { get; set; }
    }
}