using System;
using System.Collections.Generic;
using System.Linq;

namespace XbmcNet.Namespaces
{
    /// <summary>
    ///     Base class for all XBMC namespaces.
    /// </summary>
    public abstract class XbmcNamespace
    {
        protected readonly XbmcConnection Xbmc;

        internal XbmcNamespace(XbmcConnection xbmc)
        {
            Xbmc = xbmc;
        }
    }
}