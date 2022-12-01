namespace Musicplayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.CreatePlaylist();
            user.CreatePlaylist();
            user.CreatePlaylist();
            user.DisplayAllPlaylists();

            /*if(DateTime.TryParse(Console.ReadLine(), out DateTime releaseDate))
            {
                Song song = new Song("Flying without wings", "Westlife", releaseDate);
                song.PostSongDetails();
            }
            else
            {
                Console.WriteLine("Wrong input");
            }*/

           
        }
    }
}