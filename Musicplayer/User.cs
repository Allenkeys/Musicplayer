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
            string playlistName = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty(playlistName))
            {
                Console.WriteLine("Playlist name cannot be empty");
                CreatePlaylist();
            }
            else
            {
                Playlist playlist = new Playlist(playlistName);
                Console.WriteLine("Would you like to add new songs to this playlist?\nEnter Y/N");
                string addSongRequest = Console.ReadLine().ToUpper().Trim();
                switch (addSongRequest)
                {
                    case "Y":
                    Start: Console.WriteLine("Enter title of the song");
                        string songTitle = Console.ReadLine();
                        Console.WriteLine("Enter name of the music artiste");
                        string songArtiste = Console.ReadLine();
                        Console.WriteLine("Please enter the song release date in the format - DD/MM/YY");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime releaseDate) && !string.IsNullOrEmpty(songTitle) && !string.IsNullOrEmpty(songArtiste))
                        {
                            playlist.AddSongToPlaylist(songTitle, songArtiste, releaseDate);

                            Console.WriteLine($"Would you like to add more songs to {playlistName.ToUpper()} playlist?\nEnter Y/Any key");
                            string repeat = Console.ReadLine().ToUpper().Trim();
                            if (!string.IsNullOrEmpty(addSongRequest) && repeat == "Y")
                            {
                                goto Start;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your inputs are invalid...\nPlease ensure you enter inputs for title and artiste\nEnsure you entered release date in this format - DD/MM/YY\n");
                            goto Start;
                        }
                        break;

                    default: break;
                }
                _playlists.Add(playlist);
                playlist.DisplayPlaylistSongs();
                InstantDisplayPlaylisSongs();

            }

        }



        public void play()
        {
            DisplayAllPlaylists();
            Console.WriteLine("");
        }

        public Playlist SearchPlaylist(string playlistName)
        {
            Playlist? playlist = _playlists.FirstOrDefault(playlist => playlist.PlaylistName == playlistName);
            if (playlist == null)
            {
                Console.WriteLine("Sorry, playlist does not exit...");
            }
            return playlist;
        }

        public void DisplayAllPlaylists()
        {
            int counter = 1;
            foreach (var playlist in _playlists)
            {
                Console.WriteLine($"{counter++}. {playlist.PlaylistName} playlist total number of songs: {playlist._playListSongs.Count()}");
            }
        }

        public void InstantDisplayPlaylisSongs()
        {
            string? userPlaylistSearch = Console.ReadLine().Trim().ToUpper();
            var result = from playlist in _playlists
                         from songs in playlist._playListSongs
                         where playlist.PlaylistName == userPlaylistSearch
                         select songs;



            foreach (var song in result)
            {
                Console.WriteLine($"{song.Title}: {song.Artiste} : {song.ReleaseDate.ToShortDateString()}");
            }
        }

    }
}
