using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.List.Item
{
    /// <summary>
    /// 6.12.27 List.Item.All
    /// </summary>
    public class All : List.Item.Base
    {
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}