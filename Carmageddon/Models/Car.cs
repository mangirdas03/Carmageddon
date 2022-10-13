namespace Carmageddon.Forms.Models
{
    public abstract class Car
    {
        public enum CarSize
        {
            Small,
            Medium,
            Big,
        }

        protected int Health { get; set; }
        protected int Length { get; set; }
        protected string Image { get; set; }

        public (int, int, string) GetInfo()
        {
            return (Health, Length, Image);
        }
    }
}
