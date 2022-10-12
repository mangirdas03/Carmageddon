using Carmageddon.API.Models;
using Carmageddon.API.Strategy;
using Microsoft.AspNetCore.SignalR;

namespace Carmageddon.API.Hubs
{
    public class ConnectionHub : Hub
    {
        private static GameStatusModel _gameStatusModel = new GameStatusModel()
        {
            PlayerCount = 0,
            BattleDuration = DateTime.MinValue,
            MovesCount = 0,
            PlayerNames = new List<string>()
        };

        public async IAsyncEnumerable<GameStatusModel> GetPlayerCount(CancellationToken cancellationToken, Player player)
        {
            var gameStatus = new GameStatus(new PlayerCount());
            while (true)
            {
                if(!PlayersList.CheckIfExists(player))
                {
                    if(PlayersList.GetCount() == 0)
                    {
                        Task.Factory.StartNew(() => BattleDurationStatic.CountDuration());
                    }
                    PlayersList.AddPlayer(player);
                }

                yield return gameStatus.ExecuteStrategy(_gameStatusModel);
                await Task.Delay(1000, cancellationToken);
            }
        }

        public async IAsyncEnumerable<GameStatusModel> GetBattleDuration(CancellationToken cancellationToken)
        {
            var gameStatus = new GameStatus(new BattleDuration());
            while (true)
            {
                yield return gameStatus.ExecuteStrategy(_gameStatusModel);
                await Task.Delay(1000, cancellationToken);
            }
        }

        public async IAsyncEnumerable<GameStatusModel> GetMovesCount(CancellationToken cancellationToken, bool playerShoot)
        {
            var gameStatus = new GameStatus(new MovesCount());
            while (true)
            {
                if (!playerShoot)
                {
                    yield return _gameStatusModel;
                    continue;
                }

                playerShoot = false;
                yield return gameStatus.ExecuteStrategy(_gameStatusModel);
                await Task.Delay(1000, cancellationToken);
            }
        }

        public async IAsyncEnumerable<GameStatusModel> GetPlayerNames(CancellationToken cancellationToken)
        {
            var gameStatus = new GameStatus(new PlayerNames());
            while (true)
            {
                yield return gameStatus.ExecuteStrategy(_gameStatusModel);
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
