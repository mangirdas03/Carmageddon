namespace Carmageddon.API.Models
{
    public class BigCar : Car
    {
        public BigCar(int health, int length, string image)
        {
            this.Health = health;
            this.Length = length;
            this.Image = image;
        }
    }
}
