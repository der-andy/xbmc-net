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

        [JsonProperty("showtitle")]
        public string ShowTitle { get; set; }
    }
}