﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    /// 6.20.7 Video.Details.Movie
    /// </summary>
    public class Movie : File
    {
        [JsonProperty("movieid")]
        public int MovieId { get; set; }

        [JsonProperty("originaltitle")]
        public string OriginalTitle { get; set; }

        [JsonProperty("imdbnumber")]
        public string ImdbNumber { get; set; }
    }
}