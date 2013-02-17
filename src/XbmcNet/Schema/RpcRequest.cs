using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class RpcRequest
    {
        private RpcRequest()
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
        public string Id { get; private set; }
    }
}