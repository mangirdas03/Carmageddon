namespace Carmageddon.Forms.Models
{
    public abstract class Car
    {
        protected int Health { get; set; }
        protected int Length { get; set; }

        public (int, int) GetInfo()
        {
            return (Health, Length);
        }
    }
}
