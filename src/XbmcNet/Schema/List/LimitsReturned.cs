using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.List
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class LimitsReturned
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}