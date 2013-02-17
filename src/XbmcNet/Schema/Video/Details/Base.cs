using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    /// 6.20.2 Video.Details.Base
    /// </summary>
    public class Base : Schema.Media.Details.Base
    {
        [JsonProperty("playcount")]
        public int? PlayCount { get; set; }
    }
}
