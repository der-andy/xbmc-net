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
        public Player(XbmcConnection xbmc)
            : base(xbmc)
        {
        }

        [PublicAPI]
        public async Task<ActivePlayer[]> GetActivePlayers()
        {
            return await Xbmc.SendRequest<ActivePlayer[]>(new RpcRequest("Player.GetActivePlayers"));
        }

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


        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class ActivePlayer
        {
            [JsonProperty("playerid")]
            public int PlayerId { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class GetItemResponse
        {
            [JsonProperty("item")]
            public All Item { get; set; }
        }
    }
}