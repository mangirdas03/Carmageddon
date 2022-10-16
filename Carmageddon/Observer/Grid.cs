namespace Carmageddon.Forms.Observer
{
    // SUBJECT / PUBLISHER
    internal class Grid
    {
        private readonly string[] axisXCoords = 
            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};

        List<Cell> cells = new();

        public Grid(Form2 form2)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var axisYCoords = y + 1;
                    cells.Add(new Cell(form2, axisXCoords[x] + axisYCoords, x*50, y*50));
                }
            }
        }

        public void CheckCell(string coords)
        {
            foreach (var cell in cells)
            {
                cell.CheckIfHit(coords);
            }
        }
    }
}
