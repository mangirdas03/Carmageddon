using Carmageddon.API.Strategy;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace Carmageddon.API.Hubs
{
    public class BattleHub : Hub
    {
        public async IAsyncEnumerable<bool> CheckShot([EnumeratorCancellation] CancellationToken cancellationToken, string type)
        {
            var rng = new Random();
            yield return rng.Next(10) <= 1 ? true: false;
            await Task.Delay(1000, cancellationToken);
        }

    }
}
