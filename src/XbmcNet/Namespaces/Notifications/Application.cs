using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Namespaces.Notifications
{
    /// <summary>
    ///     Represents the method that will handle a OnVolumeChanged event.
    /// </summary>
    /// <param name="sender">The XBMC connection which received the notification.</param>
    /// <param name="args">The arguments received within the notification.</param>
    public delegate void OnVolumeChangedEventHandler(XbmcConnection sender, OnVolumeChangedEventArgs args);

    /// <summary>
    ///     Event arguments passed to the OnVolumeChanged event (7.1.1)
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OnVolumeChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Returns the volume.
        /// </summary>
        [JsonProperty("volume")]
        public int Volume { get; internal set; }

        /// <summary>
        ///     Returns a value indicating the mute status.
        /// </summary>
        [JsonProperty("muted")]
        public bool Muted { get; internal set; }
    }
}