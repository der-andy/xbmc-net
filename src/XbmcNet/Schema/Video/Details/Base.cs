using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    ///     6.20.2 Video.Details.Base
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Base : Schema.Media.Details.Base
    {
        [JsonProperty("playcount")]
        public int? PlayCount { get; set; }
    }
}
