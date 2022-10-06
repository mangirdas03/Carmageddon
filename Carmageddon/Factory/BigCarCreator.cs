using Carmageddon.Forms.Models;

namespace Carmageddon.Forms.Factory
{
    public class BigCarCreator : CarCreator
    {
        public override Car CreateCar()
        {
            return new BigCar(3, 3);
        }
    }
}
