using Carmageddon.Forms.Factory;
using Carmageddon.Forms.Models;

namespace Carmageddon
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var creator = new CarCreator();
            var car = creator.CreateCar(Car.CarSize.Small);
            Car x = car;
            Car y = car.MakeCopy();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}