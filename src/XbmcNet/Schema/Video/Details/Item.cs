using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    ///     6.20.5 Video.Details.item
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Item : Video.Details.Media
    {
        [JsonProperty("dateadded")]
        public DateTimeOffset? DateAdded { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("lastplayed")]
        public DateTimeOffset? LastPlayed { get; set; }

        [JsonProperty("plot")]
        public string Plot { get; set; }
    }
}