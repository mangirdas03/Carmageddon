using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace Carmageddon.API.Hubs
{
    public class BattleHub : Hub
    {
        public async IAsyncEnumerable<bool> CheckShot([EnumeratorCancellation] CancellationToken cancellationToken, 
            string type, int coordX, int coordY, string username)
        {
            if(username == null)
            {
                yield return false;
            }
            else
            {
                yield return CheckCollision(coordX, coordY, username);
            }
                
            await Task.Delay(1000, cancellationToken);
        }

        private bool CheckCollision(int coordX, int coordY, string username)
        {
            var enemyPlayer = PlayersList.GetEnemy(username);

            //return enemyPlayer.Cars.Any(car => car.Coordinates.Any(x => x.CoordX == coordX && x.CoordY == coordY && !x.IsDestroyed));
            if(enemyPlayer == null)
            {
                return false;
            }

            foreach (var car in enemyPlayer.Cars)
            {
                foreach (var coord in car.Coordinates)
                {
                    if(coord.CoordX == coordX && coord.CoordY == coordY && !coord.IsDestroyed)
                    {
                        coord.IsDestroyed = true;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
