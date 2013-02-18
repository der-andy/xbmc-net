using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace XbmcNet.Namespaces
{
    /// <summary>
    ///     Base class for all XBMC namespaces.
    /// </summary>
    public abstract class XbmcNamespace
    {
        internal readonly XbmcConnection Xbmc;

        internal XbmcNamespace(XbmcConnection xbmc)
        {
            Xbmc = xbmc;
        }

        /// <summary>
        ///     Calls the event handler for the specified method in the specified namespace and passes
        ///     the specified data to it, cast to the corresponding event arguments class.
        /// </summary>
        internal void ProcessNotification(string method, JObject data)
        {
            FieldInfo evt = GetType().GetField(method, BindingFlags.Instance | BindingFlags.NonPublic);
            if (evt == null)
            {
                return;
            }

            // the properties have all internal setters
            var serializer = new JsonSerializer
                                 {
                                     ContractResolver = new DefaultContractResolver
                                                            {
                                                                DefaultMembersSearchFlags =
                                                                    BindingFlags.Instance | BindingFlags.Public |
                                                                    BindingFlags.NonPublic
                                                            }
                                 };

            object eventArgs = data.ToObject(evt.FieldType, serializer);

            object handler = evt.GetValue(this);

            if (handler != null)
            {
                MethodInfo invoke = handler.GetType().GetMethod("Invoke");
                invoke.Invoke(handler, new[] { Xbmc, eventArgs });
            }
        }
    }
}