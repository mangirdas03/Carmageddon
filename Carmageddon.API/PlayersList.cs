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


        public static Player GetEnemy(string username)
        {
            return _players.FirstOrDefault(x => x.Username != username);
        }

        public static int GetCount()
        {
            return _players.Count;
        }

        public static List<string> GetPlayerNames()
        {
            var names = new List<string>();
            foreach (var player in _players)
            {
                names.Add(player.Username);
            }
            return names;
        }

        public static void AddPlayerCars(Player player, List<Car> cars)
        {
            if (!CheckIfExists(player))
            {
                return;
            }
            foreach (var user in _players)
            {
                if(user.Username == player.Username)
                {
                    user.Cars = cars;
                }
            }
        }
    }
}
