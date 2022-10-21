using Carmageddon.Forms;
using Carmageddon.Forms.AbstractFactory;
using Carmageddon.Forms.Adapter;
using Carmageddon.Forms.Facade;
using Carmageddon.Forms.Factory;
using Carmageddon.Forms.Models;
using Carmageddon.Forms.Observer;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        private Player _player;
        private WeaponFactory _weaponFactory;
        private Car selectedCar;
        private Car previousCar;
        private IGrid _enemyGrid;
        private Stack<Image> previousImages = new Stack<Image>();
        private Stack<Car> _cars = new Stack<Car>();
        private bool rotate = false;
        private bool stop = false;
        private bool display = false;
        private bool displayShots = false;
        private Stopwatch stopWatch = new();

        public Form2(HubConnection conn, Player player)
        {
            IConsoleLogger logger = new ConsoleLoggerAdapter();
            logger.LogMessage("Player " + player.Username + " has logged in", false);
            _enemyGrid = new Grid(this);
            _conn = conn;
            _player = player;
            InitializeComponent();
            comboBox1.Text = "--Select stats--";
            comboBox1.Items.Add("Player count");
            comboBox1.Items.Add("Battle duration");
            comboBox1.Items.Add("Player names");
            comboBox1.Items.Add("Total shots");

            stopWatch.Start();

            label10.Visible = false;
        }

        private async Task GetPlayerCount(HubConnection conn, Player player)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerCount", player))
            {
                label8.Text = "Connected players: " + model.PlayerCount.ToString();
                if (stop)
                {
                    break;
                }
            }
        }

        private async Task GetBattleDuration(HubConnection conn)
        {
            stop = false;
            display = true;
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetBattleDuration"))
            {
                if (display)
                {
                    label8.Text = "Battle duration: " + model.BattleDuration.ToLongTimeString();
                }
                if (stop)
                {
                    break;
                }
            }
        }

        private async Task GetTotalShots(HubConnection conn, bool playerShot)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetMovesCount", playerShot))
            {
                if (displayShots)
                {
                    label8.Text = "Total shots: " + model.MovesCount.ToString();
                }
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
                if (stop)
                {
                    break;
                }
            }
        }

        private async Task SendCarsToApi(List<Car> cars)
        {
            string json = JsonConvert.SerializeObject(cars);
            await _conn.SendAsync("SavePlayerCars", _player, json);
        }

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
                    cellPressed += "A";
                    coordX = 0;
                    break;
                case < 100:
                    cellPressed += "B";
                    coordX = 50;
                    break;
                case < 150:
                    cellPressed += "C";
                    coordX = 100;
                    break;
                case < 200:
                    cellPressed += "D";
                    coordX = 150;
                    break;
                case < 250:
                    cellPressed += "E";
                    coordX = 200;
                    break;
                case < 300:
                    cellPressed += "F";
                    coordX = 250;
                    break;
                case < 350:
                    cellPressed += "G";
                    coordX = 300;
                    break;
                case < 400:
                    cellPressed += "H";
                    coordX = 350;
                    break;
                case < 450:
                    cellPressed += "I";
                    coordX = 400;
                    break;
                case < 501:
                    cellPressed += "J";
                    coordX = 450;
                    break;
                default:
                    cellPressed += "A";
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
            if (selectedCar != null)
            {
                _cars.Push(selectedCar);
                (_, _, string image) = selectedCar.GetInfo();
                Image background;
                using (var bmpTemp = new Bitmap(pictureBox1.Image))
                {
                    background = new Bitmap(bmpTemp);
                }
                previousImages.Push(pictureBox1.Image);
                string carpath = Directory.GetCurrentDirectory() + "\\Resources\\" + image;
                Image car;
                using (var bmpTemp = new Bitmap(carpath))
                {
                    car = new Bitmap(bmpTemp);
                }
                if (rotate)
                    car.RotateFlip(RotateFlipType.Rotate90FlipX);
                Graphics carImage = Graphics.FromImage(background);
                carImage.DrawImage(car, coordX, coordY);
                pictureBox1.Image = background;
                selectedCar = null;
                label5.Text = "";
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
                    cellPressed += "A";
                    break;
                case < 100:
                    cellPressed += "B";
                    break;
                case < 150:
                    cellPressed += "C";
                    break;
                case < 200:
                    cellPressed += "D";
                    break;
                case < 250:
                    cellPressed += "E";
                    break;
                case < 300:
                    cellPressed += "F";
                    break;
                case < 350:
                    cellPressed += "G";
                    break;
                case < 400:
                    cellPressed += "H";
                    break;
                case < 450:
                    cellPressed += "I";
                    break;
                case < 501:
                    cellPressed += "J";
                    break;
                default:
                    cellPressed += "A";
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
            _enemyGrid.CheckCell(cellPressed);
            GetTotalShots(_conn, true);

            ////////////////////////////////////////
            Decision decision = new();

            ClickInput input = new(cellPressed);

            bool shouldReset = decision.ShouldReset(input, label10.Visible).Item1;
            bool visibilityFlag = decision.ShouldReset(input, label10.Visible).Item2;

            if (shouldReset)
            {
                stopWatch.Reset();
                label10.Visible = visibilityFlag;
                stopWatch.Start();
            }
            ///////////////////////////////////////
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = "Time since last shot: " + stopWatch.Elapsed.ToString("mm\\:ss");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var bmpTemp = new Bitmap(Directory.GetCurrentDirectory() + "\\Resources\\500x500.png"))
            {
                pictureBox1.Image = new Bitmap(bmpTemp);
                pictureBox2.Image = new Bitmap(bmpTemp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            Car car;
            if(previousCar != null && previousCar.Health == 1)
            {
                car = previousCar.MakeCopy();
            }
            else
            {
                car = carCreator.CreateCar(CarSize.Small);
                previousCar = car;
            }
            label5.Text = "Car selected: " + car.Health + " " + car.Length;
            selectedCar = car;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            Car car;
            if (previousCar != null && previousCar.Health == 2)
            {
                car = previousCar.MakeCopy();
            }
            else
            {
                car = carCreator.CreateCar(CarSize.Medium);
                previousCar = car;
            }
            label5.Text = "Car selected: " + car.Health + " " + car.Length;
            selectedCar = car;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            Car car;
            if (previousCar != null && previousCar.Health == 3)
            {
                car = previousCar.MakeCopy();
            }
            else
            {
                car = carCreator.CreateCar(CarSize.Big);
                previousCar = car;
            }
            label5.Text = "Car selected: " + car.Health + " " + car.Length;
            selectedCar = car;
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
                _cars.Pop();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (rotate == false)
                rotate = true;
            else
                rotate = false;
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            var cars = _cars.ToList();
            await SendCarsToApi(cars);
            // send cars to backend
        }

        public void AddShot(string coords, int coordX, int coordY)
        {
            Debug.WriteLine("New shot made: " + coords);
            Image background;
            using (var bmpTemp = new Bitmap(pictureBox2.Image))
            {
                background = new Bitmap(bmpTemp);
            }
            string imgpath = Directory.GetCurrentDirectory() + "\\Resources\\hit.png";
            Image hitmark;
            using (var bmpTemp = new Bitmap(imgpath))
            {
                hitmark = new Bitmap(bmpTemp);
            }
            Graphics carImage = Graphics.FromImage(background);
            carImage.DrawImage(hitmark, coordX, coordY);
            pictureBox2.Image = background;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            display = false;
            displayShots = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    stop = true;
                    GetPlayerCount(_conn, _player);
                    break;
                case 1:
                    stop = true;
                    GetBattleDuration(_conn);
                    break;
                case 2:
                    stop = true;
                    GetPlayerNames(_conn);
                    break;
                case 3:
                    stop = true;
                    displayShots = true;
                    GetTotalShots(_conn, false);
                    break;
            }
        }
    }
}
