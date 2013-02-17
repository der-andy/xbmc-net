using System;
using System.Collections.Generic;
using System.Linq;

namespace XbmcNet.Schema.Video
{
    public static class Fields
    {
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
                               "setid"
                           };
            }
        }
    }
}
