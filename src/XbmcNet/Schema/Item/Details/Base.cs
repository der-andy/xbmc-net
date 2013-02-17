using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.Item.Details
{
    /// <summary>
    ///     6.10.1 Item.Details.Base
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Base
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}