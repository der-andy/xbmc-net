using System;
using System.Collections.Generic;
using System.Linq;

namespace XbmcNet.Schema.Video
{
    /// <summary>
    /// Contains field definitions.
    /// </summary>
    public static class Fields
    {
        /// <summary>
        ///     6.20.14 Returns all requestable fields for movie requests (Video.Fields.Movie)
        /// </summary>
        public static string[] Movie
        {
            get
            {
                return new[]
                           {
                               "title",
                               "genre",
                               "year",
                               "rating",
                               "director",
                               "trailer",
                               "tagline",
                               "plot",
                               "plotoutline",
                               "originaltitle",
                               "lastplayed",
                               "dateadded",
                               "tag",
                               "playcount",
                               "writer",
                               "studio",
                               "mpaa",
                               "cast",
                               "country",
                               "imdbnumber",
                               "runtime",
                               "set",
                               "showlink",
                               "streamdetails",
                               "top250",
                               "votes",
                               "fanart",
                               "thumbnail",
                               "file",
                               "sorttitle",
                               "resume",
                               "setid",
                               "art"
                           };
            }
        }
    }
}
