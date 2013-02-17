using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema
{
    internal abstract class RpcResponse
    {
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}