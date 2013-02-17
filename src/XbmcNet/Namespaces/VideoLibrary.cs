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
    /// <summary>
    ///     Provides access to the functions of the XBMC VideoLibrary namespace.
    /// </summary>
    public class VideoLibrary : XbmcNamespace
    {
        internal VideoLibrary(XbmcConnection xbmc)
            : base(xbmc)
        {
        }

        /// <summary>
        ///     5.12.9 Retrieve all movies
        /// </summary>
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

        /// <summary>
        ///     5.12.6 Retrieve details about a specific movie
        /// </summary>
        [PublicAPI]
        public async Task<Movie> GetMovieDetails(int movieId)
        {
            var request = new RpcRequest("VideoLibrary.GetMovieDetails")
                              {
                                  Params = new
                                               {
                                                   movieid = movieId,
                                                   properties = Schema.Video.Fields.Movie
                                               }
                              };

            GetMovieDetailsResult result = await Xbmc.SendRequest<GetMovieDetailsResult>(request);

            return result.MovieDetails;
        }

        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        private class GetMovieDetailsResult
        {
            [JsonProperty("moviedetails")]
            public Movie MovieDetails { get; set; }
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