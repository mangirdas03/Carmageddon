using Carmageddon.Forms.Prototype;

namespace Carmageddon.Forms.Models
{
    public abstract class Car : IPrototype
    {
        public enum CarSize
        {
            Small,
            Medium,
            Big,
        }

        public int Health { get; set; }
        public int Length { get; set; }
        public string Image { get; set; }

        public (int, int, string) GetInfo()
        {
            return (Health, Length, Image);
        }

        public Car MakeShallowCopy()
        {
            return (Car)this.MemberwiseClone();
        }

        public Car MakeDeepCopy()
        {
            var car = (Car)Activator.CreateInstance(this.GetType());
            car.Length = this.Length;
            car.Health = this.Health;
            return car;
        }
    }
}
