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
                //Suggest adding a song on the playlist to the user
                Console.WriteLine("Would you like to add new songs to this playlist?\n Enter Y/N");
                string yesOrNo = Console.ReadLine().ToUpper().Trim();
                switch (yesOrNo)
                {
                    case "Y": playlist.AddSongToPlaylist("Hello", "Adele", new DateTime(12, 12, 12)); break;
                    //case "N": break;
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


       /* Console.WriteLine("enter playlist name:");
        string? playListName = Console.ReadLine();
        Playlist playlist = new Playlist(playListName);
        playlist.AddSongToPlaylist("Holla", "Unknown", new DateTime(2012, 12, 2));
            playlist.AddSongToPlaylist("Hello", "Adele", new DateTime(2010, 12, 2));
            playlist.AddSongToPlaylist("Aye", "Davido", new DateTime(2011, 10, 2));
            playlist.DisplayPlaylist();
            Console.WriteLine("Enter song title to delete");
            string songTitle = Console.ReadLine().ToUpper();
        playlist.RemoveSongFromPlaylist(songTitle);
           // Console.WriteLine("enter new name");
            playlist.RenameSong();*/
    }
}
