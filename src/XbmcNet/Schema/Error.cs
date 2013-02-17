using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Schema
{
    /// <summary>
    ///     Represents a JSON RPC error result from the XBMC server.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Error
    {
        /// <summary>
        ///     Returns the JSON RPC error code.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        ///     Returns the error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///     Returns additional data about the error.
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}