using Carmageddon.API.Models;
using Microsoft.AspNetCore.SignalR;

namespace Carmageddon.API.Hubs
{
    public class ConnectionHub : Hub
    {
        public async IAsyncEnumerable<int> Streaming(CancellationToken cancellationToken, Player player)
        {
            while (true)
            {
                if(!PlayersList.CheckIfExists(player))
                {
                    PlayersList.AddPlayer(player);
                }
                yield return PlayersList.GetCount();
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
