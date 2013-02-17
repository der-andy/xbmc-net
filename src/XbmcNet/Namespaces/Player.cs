using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;
using XbmcNet.Schema;
using XbmcNet.Schema.List.Item;

namespace XbmcNet.Namespaces
{
    /// <summary>
    ///     Provides access to the functions of the XBMC Player namespace.
    /// </summary>
    public class Player : XbmcNamespace
    {
        internal Player(XbmcConnection xbmc)
            : base(xbmc)
        {
        }

        /// <summary>
        ///     5.9.1 Returns all active players
        /// </summary>
        [PublicAPI]
        public async Task<ActivePlayer[]> GetActivePlayers()
        {
            return await Xbmc.SendRequest<ActivePlayer[]>(new RpcRequest("Player.GetActivePlayers"));
        }

        /// <summary>
        ///     5.9.2 Retrieves the currently played item
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [PublicAPI]
        public async Task<All> GetItem(int playerId)
        {
            GetItemResponse response = await Xbmc.SendRequest<GetItemResponse>(new RpcRequest("Player.GetItem")
                                                                                   {
                                                                                       Params = new
                                                                                                    {
                                                                                                        playerid = playerId
                                                                                                    }
                                                                                   });
            return response.Item;
        }

        /// <summary>
        /// Represents an active player (video or audio).
        /// </summary>
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class ActivePlayer
        {
            /// <summary>
            /// Returns the ID of this player.
            /// </summary>
            [JsonProperty("playerid")]
            public int PlayerId { get; set; }

            /// <summary>
            /// Returns the type of this player, i.e. audio or video.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }
        }

        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        private class GetItemResponse
        {
            [JsonProperty("item")]
            public All Item { get; set; }
        }
    }
}