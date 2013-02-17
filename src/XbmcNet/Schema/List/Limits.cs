using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.List
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class Limits
    {
        public Limits()
        {
        }

        public Limits(int start = 0, int end = -1)
        {
            Start = start;
            End = end;
        }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }
    }
}