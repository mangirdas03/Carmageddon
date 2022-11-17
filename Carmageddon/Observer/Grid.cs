using Carmageddon.Forms.Models;
using Carmageddon.Forms.TemplateMethod;

namespace Carmageddon.Forms.Observer
{
    // SUBJECT / PUBLISHER
    internal class Grid : IGrid
    {
        private readonly string[] axisXCoords = 
            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};

        List<ICell> cells = new();

        public List<Car> Cars = new List<Car>();
        public CarPlacer CarPlacer { get; set; }
        public string State { get; set; }

        public Grid(Form2 form2)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var axisYCoords = y + 1;
                    cells.Add(new Cell(this, form2, axisXCoords[x] + axisYCoords, x*50, y*50));
                }
            }
        }

        // notify all
        public void CheckCell(string coords)
        {
            State = coords;
            foreach (var cell in cells)
            {
                cell.CheckIfHit();
            }
        }

        public bool AddCar(Car car)
        {
            // if true add to list
            if (CarPlacer.TemplateMethod(car, Cars))
            {
                Cars.Add(car);
                return true;
            }

            return false;
        }
    }
}
