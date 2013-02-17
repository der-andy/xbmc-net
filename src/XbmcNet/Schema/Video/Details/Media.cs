using System.Linq;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    /// 6.20.6 Video.Details.Media
    /// </summary>
    public class Media : Video.Details.Base
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}