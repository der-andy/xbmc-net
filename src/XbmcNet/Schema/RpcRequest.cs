using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet.Schema
{
    internal class RpcRequest
    {
        public RpcRequest()
        {
            Id = Tools.GenerateString();
        }

        public RpcRequest(string method)
            : this()
        {
            Method = method;
        }

        [JsonProperty("jsonrpc")]
        public string JsonRpc
        {
            get { return "2.0"; }
        }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)]
        public object Params { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}