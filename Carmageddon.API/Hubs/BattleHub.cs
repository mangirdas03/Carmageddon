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

        public async IAsyncEnumerable<bool> CheckIfAllCarsDestroyed([EnumeratorCancellation] CancellationToken cancellationToken, string username)
        {
            if (username == null)
            {
                yield return false;
            }
            else
            {
                yield return CheckAllCars(username);
            }

            await Task.Delay(1000, cancellationToken);
        }

        public async IAsyncEnumerable<string> CheckCarState([EnumeratorCancellation] CancellationToken cancellationToken, 
            int coordX, int coordY, string username)
        {
            if (username == null)
            {
                yield return "";
            }
            else
            {
                var state = "";
                var stop = false;
                var cars = PlayersList.GetPlayerCars(username);
                foreach (var car in cars)
                {
                    foreach (var coord in car.Coordinates)
                    {
                        if (coord.CoordX == coordX && coord.CoordY == coordY)
                        {
                            state = car.Context.CarState.GetType().Name;
                            stop = true;
                            break;
                        }
                    }
                    if (stop)
                    {
                        break;
                    }
                }
                yield return state;
            }

            await Task.Delay(1000, cancellationToken);
        }

        private bool CheckAllCars(string username)
        {
            var enemyPlayer = PlayersList.GetEnemy(username);
            if (enemyPlayer == null)
            {
                return true;
            }

            foreach (var car in enemyPlayer.Cars)
            {
                foreach (var coord in car.Coordinates)
                {
                    if (!coord.IsDestroyed)
                    {
                        return false;
                    }
                }
            }

            return true;
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
                        car.Health--;
                        car.Context.ChangeState();
                        coord.IsDestroyed = true;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
