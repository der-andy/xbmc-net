using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XbmcNet.External.ReSharperAnnotations;
using XbmcNet.Schema;
using XbmcNet.Schema.List;
using XbmcNet.Schema.Video.Details;

namespace XbmcNet.Namespaces
{
    public class VideoLibrary : XbmcNamespace
    {
        /// <summary>
        ///     Provides access to the functions of the XBMC VideoLibrary namespace.
        /// </summary>
        public VideoLibrary(XbmcConnection xbmc)
            : base(xbmc)
        {
        }

        [PublicAPI]
        public async Task<Movie[]> GetMovies(int start = 0, int end = -1)
        {
            var request = new RpcRequest("VideoLibrary.GetMovies")
                              {
                                  Params = new
                                               {
                                                   limits = new Limits(start, end),
                                                   properties = Schema.Video.Fields.Movie
                                               }
                              };


            GetMoviesResult result = await Xbmc.SendRequest<GetMoviesResult>(request);

            return result.Movies;
        }

        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        private class GetMoviesResult
        {
            [JsonProperty("limits")]
            public LimitsReturned Limits { get; set; }

            [JsonProperty("movies")]
            public Movie[] Movies { get; set; }
        }
    }
}