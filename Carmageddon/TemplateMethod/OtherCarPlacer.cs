using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.TemplateMethod
{
    public class OtherCarPlacer : CarPlacer
    {
        public sealed override bool ValidateBorders(Car car)
        {
            var isValid = true;
            foreach (var item in car.Coordinates)
            {
                if (item.CoordX > 500 || item.CoordX < 0 || item.CoordY > 500 || item.CoordY < 0)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public sealed override bool ValidateCars(Car car, List<Car> cars)
        {
            var isValid = true;

            foreach (var placedCar in cars)
            {
                foreach (var coords in car.Coordinates)
                {
                    if (placedCar.Coordinates.Any(x => x.CoordX == coords.CoordX && x.CoordY == coords.CoordY))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (!isValid)
                {
                    break;
                }
            }

            return isValid;
        }
    }
}
