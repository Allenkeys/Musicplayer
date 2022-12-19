﻿using System.Text;

namespace Musicplayer
{
    internal class Playlist
    {
        internal string PlaylistName { get; set; }
        internal List<Song> _playListSongs = new List<Song>();

        public Playlist(string playlistName)
        {
            PlaylistName = playlistName;
        }

        public void AddSongToPlaylist(string title, string artiste, DateTime releaseDate)
        {
            Song song = new Song(title.ToUpper(), artiste, releaseDate);
            _playListSongs.Add(song);
            Console.WriteLine($"\"{song.Title}\" sung by {song.Artiste} and released on {song.ReleaseDate.ToShortDateString()} has been added to {PlaylistName} playlist");
        }

        public void DisplayPlaylistSongs()
        {
            StringBuilder playlist = new StringBuilder();
            playlist.AppendLine($"******************{PlaylistName.ToUpper()}*******************");
            playlist.AppendLine("TITLE\t\tARTISTE\t\tRELEASE DATE");
            foreach (var song in _playListSongs)
            {
                playlist.AppendLine($"{song.Title}\t\t{song.Artiste}\t\t{song.ReleaseDate.ToShortDateString()}");
            }
            Console.WriteLine(playlist.ToString());
        }

        public void RemoveSongFromPlaylist(string title)
        {
            Song? queryOutput = SearchSong(title);
            if (queryOutput != null)
            {
                Console.WriteLine($"{queryOutput.Title} has been successfully removed from {PlaylistName.ToUpper()} playlist.");
                _playListSongs.Remove(queryOutput);
                DisplayPlaylistSongs();
            }

        }

        public Song SearchSong(string title)
        {
            Song? song = _playListSongs.FirstOrDefault(song => song.Title == title);
            if(song == null)
            {
                Console.WriteLine("Sorry, song not found...");
            }
            return song;
        }

        

        public void RenameSong()
        {
            Console.WriteLine("Enter title of song you want to rename");
            string? query = Console.ReadLine().ToUpper();
            Song? queryOutput = SearchSong(query);
            if(queryOutput != null)
            {
                Console.WriteLine("Enter new name");
                string? newTitle = Console.ReadLine().ToUpper();

                foreach (Song song in _playListSongs)
                {
                    if (song == queryOutput)
                    {
                        song.Title = newTitle;
                    }
                }
                DisplayPlaylistSongs();
            }
        }

        public void SortPlaylist()
        {
            _playListSongs = _playListSongs.OrderBy(song => song.Title).ToList();
            foreach (var song in _playListSongs)
            {
                Console.WriteLine($"title: {song.Title}   Artiste: {song.Artiste}");
            }
        }

        public void ShufflePlaylist()
        {
            Random rand = new Random();
            _playListSongs = (List<Song>)_playListSongs.OrderBy(Song => rand.Next());
            foreach (var song in _playListSongs)
            {
                Console.WriteLine($"title: {song.Title}   Artiste: {song.Artiste}");
            }
        }
    }
}
