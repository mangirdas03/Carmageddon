using Carmageddon.Forms.Models;

namespace Carmageddon.Forms.Factory
{
    public class MediumCarCreator : CarCreator
    {
        public override Car CreateCar()
        {
            return new MediumCar(2, 2);
        }
    }
}
