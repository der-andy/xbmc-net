using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.List.Item
{
    /// <summary>
    ///     6.12.28 List.Item.Base
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Base : Video.Details.File // also inherits from Audio.Details.Media
    {
        [JsonProperty("sorttitle")]
        public string SortTitle { get; set; }

        [JsonProperty("productioncode")]
        public string ProductionCode { get; set; }

        [JsonProperty("votes")]
        public string Votes { get; set; }

        [JsonProperty("duration"), JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan? Duration { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("albumid")]
        public int? AlbumId { get; set; }

        [JsonProperty("top250")]
        public int? Top250 { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("showtitle")]
        public string ShowTitle { get; set; }
    }
}