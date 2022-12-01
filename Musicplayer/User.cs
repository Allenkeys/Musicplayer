using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicplayer
{
    internal class User 
    {
        public User()
        {
        }

        internal List<Playlist> _playlists = new List<Playlist>();

        public void CreatePlaylist()
        {
            Console.WriteLine("Enter name for new playlist");
            string playlistName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(playlistName))
            {
                Console.WriteLine("Playlist name cannot be empty");
                CreatePlaylist();
            }
            else
            {
                Playlist playlist = new Playlist(playlistName);
                Console.WriteLine("Would you like to add new songs to this playlist?\nEnter Y/N");
                string yesOrNo = Console.ReadLine().ToUpper().Trim();
                switch (yesOrNo)
                {
                    case "Y":
                        Start: Console.WriteLine("Enter title of the song");
                        string songTitle = Console.ReadLine();
                        Console.WriteLine("Enter name of the music artiste");
                        string songArtiste = Console.ReadLine();
                        Console.WriteLine("Please enter the song release date");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime releaseDate) && !string.IsNullOrEmpty(songTitle) && !string.IsNullOrEmpty(songArtiste))
                        {
                            playlist.AddSongToPlaylist(songTitle, songArtiste, releaseDate);

                            Console.WriteLine($"Would you like to add more songs to {playlistName.ToUpper()} playlist?\nEnter Y/N");
                            string repeat = Console.ReadLine().ToUpper().Trim();
                            if (!string.IsNullOrEmpty(yesOrNo) && repeat == "Y")
                            {
                                goto Start;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your inputs are invalid...\nPlease ensure you enter title and artiste\nEnsure you entered release date in this format - DD/MM/YY");
                        }
                        break;
                    
                    default: break;
                }
                _playlists.Add(playlist);
                playlist.DisplayPlaylist();
            }
            
        }

        public void DisplayAllPlaylists()
        {
            foreach (var playlist in _playlists)
            {
                Console.WriteLine($"{playlist.PlaylistName} playlist total number of songs: {playlist._playListSongs.Count()}");
            }
        }

    }
}
