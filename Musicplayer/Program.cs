namespace Musicplayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.CreatePlaylist();
            user.DisplayAllPlaylists();
        }
    }
}