using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.Media.Details
{
    /// <summary>
    /// 6.13.2 Media.Details.Base
    /// </summary>
    public class Base : Item.Details.Base
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("fanart")]
        public string FanArt { get; set; }
    }
}