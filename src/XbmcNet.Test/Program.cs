using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcNet.Test
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (var xbmc = new XbmcConnection("10.0.0.31", 9090))
            {
                Console.WriteLine("First few movies in your database:");
                var movies = xbmc.VideoLibrary.GetMovies(0, 10).Result;

                foreach (var movie in movies)
                {
                    Console.WriteLine("- {0} ({1}); played {2} times", movie.Title, movie.OriginalTitle, movie.PlayCount);
                }

                Console.WriteLine();
                Console.WriteLine("Currently playing:");
                foreach (var player in xbmc.Player.GetActivePlayers().Result)
                {
                    var item = xbmc.Player.GetItem(player.PlayerId).Result;
                    Console.WriteLine("Active player: ID={0}; Type={1}", player.PlayerId, player.Type);
                    Console.WriteLine("- Currently playing: {0}", item.Label);
                }
            }

            Console.ReadLine();
        }
    }
}
