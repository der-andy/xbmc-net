using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.List.Item
{
    /// <summary>
    ///     6.12.27 List.Item.All
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class All : List.Item.Base
    {
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}