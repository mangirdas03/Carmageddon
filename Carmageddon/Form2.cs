using Carmageddon.Forms;
using Carmageddon.Forms.AbstractFactory;
using Carmageddon.Forms.Factory;
using Carmageddon.Forms.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Carmageddon.Forms.Models.Car;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Carmageddon
{
    public partial class Form2 : Form
    {
        private HubConnection _conn;
        private WeaponFactory _weaponFactory;
        private string selectedCar = "";
        private Stack<Image> previousImages = new Stack<Image>();
        private bool rotate = false;
        public Form2(HubConnection conn, Player player)
        {
            _conn = conn;
            GetPlayerCount(conn, player);
            GetBattleDuration(conn);
            GetPlayerNames(conn);
            InitializeComponent();
        }

        private async Task GetPlayerCount(HubConnection conn, Player player)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerCount", player))
            {
                label2.Text = model.PlayerCount.ToString();
            }
        }

        private async Task GetBattleDuration(HubConnection conn)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetBattleDuration"))
            {
                label6.Text = "Battle duration: " + model.BattleDuration.ToLongTimeString();
            }
        }

        private async Task GetTotalShots(HubConnection conn, bool playerShot)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetMovesCount", playerShot))
            {
                label7.Text = "Total shots: " + model.MovesCount.ToString();
                break;
            }
        }

        private async Task GetPlayerNames(HubConnection conn)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerNames"))
            {
                label8.Text = "Player names:\r\n"; 
                foreach (var name in model.PlayerNames)
                {
                    label8.Text += name + "\r\n";
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var x = button1.Tag;
        //    var a = (sender as Button).Tag;
        //    var hehe = "a1";
        //}

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button201_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("test");
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var coordX = mouseEventArgs.X;
            var coordY = mouseEventArgs.Y;
            var cellPressed = "";

            //Debug.WriteLine(string.Format("X: {0} Y: {1}", coordX, coordY));

            switch (coordX)
            {
                case < 50:
                    cellPressed += "a";
                    coordX = 0;
                    break;
                case < 100:
                    cellPressed += "b";
                    coordX = 50;
                    break;
                case < 150:
                    cellPressed += "c";
                    coordX = 100;
                    break;
                case < 200:
                    cellPressed += "d";
                    coordX = 150;
                    break;
                case < 250:
                    cellPressed += "e";
                    coordX = 200;
                    break;
                case < 300:
                    cellPressed += "f";
                    coordX = 250;
                    break;
                case < 350:
                    cellPressed += "g";
                    coordX = 300;
                    break;
                case < 400:
                    cellPressed += "h";
                    coordX = 350;
                    break;
                case < 450:
                    cellPressed += "i";
                    coordX = 400;
                    break;
                case < 501:
                    cellPressed += "j";
                    coordX = 450;
                    break;
                default:
                    cellPressed += "a";
                    coordX = 0;
                    break;
            }

            switch (coordY)
            {
                case < 50:
                    cellPressed += "1";
                    coordY = 0;
                    break;
                case < 100:
                    cellPressed += "2";
                    coordY = 50;
                    break;
                case < 150:
                    cellPressed += "3";
                    coordY = 100;
                    break;
                case < 200:
                    cellPressed += "4";
                    coordY = 150;
                    break;
                case < 250:
                    cellPressed += "5";
                    coordY = 200;
                    break;
                case < 300:
                    cellPressed += "6";
                    coordY = 250;
                    break;
                case < 350:
                    cellPressed += "7";
                    coordY = 300;
                    break;
                case < 400:
                    cellPressed += "8";
                    coordY = 350;
                    break;
                case < 450:
                    cellPressed += "9";
                    coordY = 400;
                    break;
                case < 501:
                    cellPressed += "10";
                    coordY = 450;
                    break;
                default:
                    cellPressed += "1";
                    coordY = 0;
                    break;
            }
            if (selectedCar != "")
            {
                Bitmap background = new Bitmap(pictureBox1.Image);
                previousImages.Push(pictureBox1.Image);
                string carpath = Directory.GetCurrentDirectory() + "\\Resources\\" + selectedCar;
                Bitmap car = new Bitmap(Image.FromFile(carpath));
                if (rotate)
                    car.RotateFlip(RotateFlipType.Rotate90FlipX);
                Graphics carImage = Graphics.FromImage(background);
                carImage.DrawImage(car, coordX, coordY);
                pictureBox1.Image = background;
            }

            label3.Text = "Your grid cell pressed: " + cellPressed;
            Debug.WriteLine("Your grid cell pressed: " + cellPressed);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var coordX = mouseEventArgs.X;
            var coordY = mouseEventArgs.Y;
            var cellPressed = "";

            //Debug.WriteLine(string.Format("X: {0} Y: {1}", coordX, coordY));

            switch (coordX)
            {
                case < 50:
                    cellPressed += "a";
                    break;
                case < 100:
                    cellPressed += "b";
                    break;
                case < 150:
                    cellPressed += "c";
                    break;
                case < 200:
                    cellPressed += "d";
                    break;
                case < 250:
                    cellPressed += "e";
                    break;
                case < 300:
                    cellPressed += "f";
                    break;
                case < 350:
                    cellPressed += "g";
                    break;
                case < 400:
                    cellPressed += "h";
                    break;
                case < 450:
                    cellPressed += "i";
                    break;
                case < 501:
                    cellPressed += "j";
                    break;
                default:
                    cellPressed += "a";
                    break;
            }

            switch (coordY)
            {
                case < 50:
                    cellPressed += "1";
                    break;
                case < 100:
                    cellPressed += "2";
                    break;
                case < 150:
                    cellPressed += "3";
                    break;
                case < 200:
                    cellPressed += "4";
                    break;
                case < 250:
                    cellPressed += "5";
                    break;
                case < 300:
                    cellPressed += "6";
                    break;
                case < 350:
                    cellPressed += "7";
                    break;
                case < 400:
                    cellPressed += "8";
                    break;
                case < 450:
                    cellPressed += "9";
                    break;
                case < 501:
                    cellPressed += "10";
                    break;
                default:
                    cellPressed += "1";
                    break;
            }

            label4.Text = "Enemy grid cell pressed: " + cellPressed;
            Debug.WriteLine("Enemy grid cell pressed: " + cellPressed);
            GetTotalShots(_conn, true);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\500x500.png");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            var car = carCreator.CreateCar(CarSize.Small);
            (var health, var length) = car.GetInfo();
            label5.Text = "Car selected: " + health + " " + length;
            selectedCar = "small.png";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            var car = carCreator.CreateCar(CarSize.Medium);
            (var health, var length) = car.GetInfo();
            label5.Text = "Car selected: " + health + " " + length;
            selectedCar = "medium.png";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            var car = carCreator.CreateCar(CarSize.Big);
            (var health, var length) = car.GetInfo();
            label5.Text = "Car selected: " + health + " " + length;
            selectedCar = "big.png";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var option = random.Next(1, 4);
            Cannon weapon;
            switch (option)
            {
                case 1:
                    _weaponFactory = new LowAmmoFactory();
                    weapon = _weaponFactory.CreateCannon();
                    label9.Text = "Cannon selected:\r\nShots left - " + weapon.ShotsLeft;
                    break;
                case 2:
                    _weaponFactory = new MediumAmmoFactory();
                    weapon = _weaponFactory.CreateCannon();
                    label9.Text = "Cannon selected:\r\nShots left - " + weapon.ShotsLeft;
                    break;
                case 3:
                    _weaponFactory = new HighAmmoFactory();
                    weapon = _weaponFactory.CreateCannon();
                    label9.Text = "Cannon selected:\r\nShots left - " + weapon.ShotsLeft;
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var option = random.Next(1, 4);
            MachineGun weapon;
            switch (option)
            {
                case 1:
                    _weaponFactory = new LowAmmoFactory();
                    weapon = _weaponFactory.CreateMachineGun();
                    label9.Text = "MG selected:\r\nShots left - " + weapon.ShotsLeft;
                    break;
                case 2:
                    _weaponFactory = new MediumAmmoFactory();
                    weapon = _weaponFactory.CreateMachineGun();
                    label9.Text = "MG selected:\r\nShots left - " + weapon.ShotsLeft;
                    break;
                case 3:
                    _weaponFactory = new HighAmmoFactory();
                    weapon = _weaponFactory.CreateMachineGun();
                    label9.Text = "MG selected:\r\nShots left - " + weapon.ShotsLeft;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (previousImages.Count != 0)
            {
                //var img = previousImages.Last();
                //previousImages.RemoveAt(previousImages.Count - 1);
                pictureBox1.Image = previousImages.Pop();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (rotate == false)
                rotate = true;
            else
                rotate = false;
        }
    }
}
