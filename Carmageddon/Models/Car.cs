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

        public (int, int) GetInfo()
        {
            return (Health, Length);
        }
    }
}
