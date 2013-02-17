using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.Media
{
    /// <summary>
    ///     6.13.1 Media Artwork
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Artwork
    {
        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }

        [JsonProperty("fanart")]
        public string FanArt { get; set; }

        [JsonProperty("thumb")]
        public string Thumbnail { get; set; }
    }
}