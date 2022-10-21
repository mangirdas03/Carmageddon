using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Command
{
    public class Invoker
    {
        Receiver receiver = new Receiver();
        Stack<Image> previousImages = new Stack<Image>();
        Stack<Car> _cars = new Stack<Car>();
        int count = 0;

        public void AddCar(Car car, Image image)
        {
            Command command = new ConcreteCommand();
            command.Execute(car, image, _cars, previousImages);
            count++;
            receiver.Action();
        }
        public Image Undo()
        {
           if(count > 0)
            {
                Command command = new ConcreteCommand();
                count--;
                return command.Undo(_cars, previousImages);
            }
           else
                return null;
        }
        public Stack<Car> CarStack()
        {
            return _cars;
        }
    }
}
