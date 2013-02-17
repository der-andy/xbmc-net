using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    ///     6.20.7 Video.Details.Movie
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Movie : File
    {
        [JsonProperty("plotoutline")]
        public string PlotOutline { get; set; }

        [JsonProperty("sorttitle")]
        public string SortTitle { get; set; }

        [JsonProperty("movieid")]
        public int MovieId { get; set; }

        [JsonProperty("cast")]
        public Cast[] Cast { get; set; }
        
        [JsonProperty("votes")]
        public string Votes { get; set; }

        [JsonProperty("showlink")]
        public string[] ShowLink { get; set; }

        [JsonProperty("top250")]
        public int? Top250 { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("country")]
        public string[] Country { get; set; }

        [JsonProperty("studio")]
        public string[] Studio { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; }

        [JsonProperty("genre")]
        public string[] Genre { get; set; }

        [JsonProperty("mpaa")]
        public string MPAA { get; set; }

        [JsonProperty("setid")]
        public int? SetId { get; set; }

        [JsonProperty("rating")]
        public decimal Rating { get; set; }

        [JsonProperty("tag")]
        public string[] Tag { get; set; }

        [JsonProperty("tagline")]
        public string TagLine { get; set; }

        [JsonProperty("writer")]
        public string[] Writer { get; set; }
        
        [JsonProperty("originaltitle")]
        public string OriginalTitle { get; set; }

        [JsonProperty("imdbnumber")]
        public string ImdbNumber { get; set; }
    }
}