using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class XbmcResponse<T> : XbmcResponse
    {
        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
