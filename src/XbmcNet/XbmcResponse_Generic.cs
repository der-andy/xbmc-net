using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.Schema;

namespace XbmcNet
{
    public class XbmcResponse<T> : XbmcResponse where T : class
    {
        internal XbmcResponse()
        {
        }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
