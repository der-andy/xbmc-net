using System;
using System.Collections.Generic;
using System.Linq;

namespace XbmcNet
{
    public class XbmcNetException : ApplicationException
    {
        public object XbmcData { get; private set; }
        public int Code { get; private set; }

        public XbmcNetException()
        {
        }

        public XbmcNetException(string message) : base(message)
        {
        }

        public XbmcNetException(string message, int code, object data) : this(message)
        {
            Code = code;
            XbmcData = data;
        }

        public XbmcNetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}