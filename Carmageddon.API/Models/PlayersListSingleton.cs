namespace Carmageddon.API.Models
{
    public class PlayersListSingleton
    {
        private List<Player> _players = null;

        public PlayersListSingleton()
        {
        }

        public List<Player> GetInstance()
        {
            if (_players == null)
            {
                _players = new List<Player>();
            }

            return _players;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
    }
}
