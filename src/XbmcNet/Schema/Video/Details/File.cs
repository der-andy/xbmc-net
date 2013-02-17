using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema.Video.Details
{
    /// <summary>
    ///     6.20.4 Video.Details.File
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class File : Video.Details.Item
    {
        [JsonProperty("runtime"), JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? Runtime { get; set; }
    }
}