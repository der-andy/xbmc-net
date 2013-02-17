using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.List
{
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