using System;
using System.Collections.Generic;
using System.Linq;
using XbmcNet.External.ReSharperAnnotations;
using XbmcNet.Namespaces.Notifications;
using XbmcNet.Schema;

namespace XbmcNet.Namespaces
{
    /// <summary>
    ///     Provides access to the functions of the XBMC Application namespace.
    /// </summary>
    public class Application : XbmcNamespace
    {
        internal Application(XbmcConnection xbmc)
            : base(xbmc)
        {
        }

        /// <summary>
        ///     7.1.1 The volume of the application has changed.
        /// </summary>
        [PublicAPI]
        public event OnVolumeChangedEventHandler OnVolumeChanged;

        /// <summary>
        ///     5.2.2 Quit application
        /// </summary>
        [PublicAPI]
        public bool Quit()
        {
            return Xbmc.SendRequest<string>(new RpcRequest("Application.Quit")).Result == "OK";
        }

        /// <summary>
        ///     5.2.3 Toggle mute/unmute
        /// </summary>
        [PublicAPI]
        public bool SetMute(bool mute)
        {
            return Xbmc.SendRequest<bool>(new RpcRequest("Application.SetMute")
                                              {
                                                  Params = new { mute }
                                              }).Result;
        }

        /// <summary>
        ///     5.2.4 Set the current volume
        /// </summary>
        [PublicAPI]
        public int SetVolume(int volume)
        {
            if (volume < 0 || volume > 100)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0 and 100!");
            }

            return Xbmc.SendRequest<int>(new RpcRequest("Application.SetVolume")
                                             {
                                                 Params = new { volume }
                                             }).Result;
        }
    }
}
