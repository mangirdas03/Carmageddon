using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Command
{
    public class ConcreteCommand : Command
    {
        public override void Execute(Car car, Image image, Stack<Car> cars, Stack<Image> previousImages)
        {
            cars.Push(car);
            previousImages.Push(image);
        }

        public override Image Undo(Stack<Car> cars, Stack<Image> previousImages)
        {
            cars.Pop();
            return previousImages.Pop();
        }
    }
}
