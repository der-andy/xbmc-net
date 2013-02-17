using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.Item.Details
{
    /// <summary>
    /// 6.10.1 Item.Details.Base
    /// </summary>
    public class Base
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}