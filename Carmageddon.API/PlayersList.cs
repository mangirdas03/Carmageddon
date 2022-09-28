using Carmageddon.API.Models;

namespace Carmageddon.API
{
    public static class PlayersList
    {
        private static List<Player> _players = new List<Player>();

        public static bool CheckIfExists(Player player)
        {
            return _players.Any(x => x.Username == player.Username);
        }

        public static void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public static int GetCount()
        {
            return _players.Count;
        }
    }
}
