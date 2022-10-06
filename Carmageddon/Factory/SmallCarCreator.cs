using Carmageddon.Forms.Models;

namespace Carmageddon.Forms.Factory
{
    public class SmallCarCreator : CarCreator
    {
        public override Car CreateCar()
        {
            return new SmallCar(1, 1);
        }
    }
}
