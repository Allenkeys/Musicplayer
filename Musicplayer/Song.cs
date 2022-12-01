using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicplayer
{
    internal class Song
    {
        internal string Title { get; set; }
        internal string Artiste { get; set; }
        internal DateTime ReleaseDate { get; set; }

        public Song(string title, string artiste, DateTime releaseDate)
        {
            Title = title;
            Artiste = artiste;
            ReleaseDate = releaseDate;
        }

        
        public void PostSongDetails()
        {
            Console.WriteLine($"The song - {Title} was sung by {Artiste} and released on {ReleaseDate.ToShortDateString()}");
        }
    }
}
 