using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XbmcNet.External.ReSharperAnnotations;

namespace XbmcNet.Namespaces.Notifications
{
    #region General

    public class Player
    {
        [JsonProperty("speed")]
        public int? Speed { get; internal set; }

        [JsonProperty("playerid")]
        public int PlayerId { get; internal set; }
    }

    #endregion

    #region 7.4.1 OnPause

    /// <summary>
    ///     Represents the method that will handle a OnPause, OnPlay or OnSpeedChanged event.
    /// </summary>
    /// <param name="sender">The XBMC connection which received the notification.</param>
    /// <param name="args">The arguments received within the notification.</param>
    public delegate void PlaybackEventHandler(XbmcConnection sender, PlaybackEventArgs args);

    /// <summary>
    ///     Event arguments passed to OnPause (7.4.1), OnPlay (7.4.2) or OnSpeedChanged (7.4.5)
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class PlaybackEventArgs : EventArgs
    {
        /// <summary>
        ///     Returns the player.
        /// </summary>
        [JsonProperty("player")]
        public Player Player { get; internal set; }

        /// <summary>
        ///     Returns the item currently being played.
        /// </summary>
        [JsonProperty("item")]
        public JObject Item { get; internal set; }
    }

    #endregion
}
