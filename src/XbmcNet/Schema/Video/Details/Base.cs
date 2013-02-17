using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;
using XbmcNet.Schema.Media;

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

        [JsonProperty("art")]
        public Artwork Art { get; set; }
    }
}
