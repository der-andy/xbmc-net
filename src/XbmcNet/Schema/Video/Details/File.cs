using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    /// 6.20.4 Video.Details.File
    /// </summary>
    public class File : Video.Details.Item
    {
        [JsonProperty("runtime")]
        public int? Runtime { get; set; }
    }
}