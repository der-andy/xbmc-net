﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;
using XbmcNet.Schema;

namespace XbmcNet
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class XbmcResponse
    {
        protected XbmcResponse()
        {
        }

        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}