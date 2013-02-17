using System;
using System.Collections.Generic;
using System.Linq;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet
{
    /// <summary>
    ///     Exception type thrown by the XbmcNet library.
    /// </summary>
    [PublicAPI]
    public class XbmcNetException : ApplicationException
    {
        /// <summary>
        ///     Returns she contents of the additional error data field of the corresponding JSON RPC error response.
        ///     (Only if the exception was caused by a JSON RPC error response.)
        /// </summary>
        [PublicAPI]
        public object XbmcData { get; private set; }

        /// <summary>
        ///     Returns teh error code of the corresponding JSON RPC error response.
        ///     (Only if the exception was caused by a JSON RPC error response.)
        /// </summary>
        [PublicAPI]
        public int Code { get; private set; }

        internal XbmcNetException()
        {
        }

        internal XbmcNetException(string message) : base(message)
        {
        }

        internal XbmcNetException(string message, int code, object data) : this(message)
        {
            Code = code;
            XbmcData = data;
        }

        internal XbmcNetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}