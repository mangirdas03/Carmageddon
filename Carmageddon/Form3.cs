using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carmageddon.Forms
{
    public partial class Form3 : Form
    {
        private string carType = "";
        private string carColor = "";
        private Image _car;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\small.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            carType = "small";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\medium.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            carType = "medium";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\big.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            carType = "big";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\"+ carType +"_green.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            carColor = "_green";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + carType + "_purple.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            carColor = "_purple";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string carpath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + carType + "_yellow.png";
            using (var bmpTemp = new Bitmap(carpath))
            {
                _car = new Bitmap(bmpTemp);
            }
            pictureBox1.Image = _car;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            carColor = "_yellow";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            string imagePathNew = Directory.GetCurrentDirectory() + "\\Resources\\Models\\" + carType + carColor + ".png";
            string removePathOld = Directory.GetCurrentDirectory() + "\\Resources\\" + carType + ".png";
            if (File.Exists(removePathOld) && File.Exists(imagePathNew))
            {
                File.Delete(removePathOld);
                File.Copy(imagePathNew, removePathOld);
                label1.Text = carType + " car has been updated!";
                pictureBox1.Image = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string smallCar = Directory.GetCurrentDirectory() + "\\Resources\\Models\\small_default.png";
            string mediumCar = Directory.GetCurrentDirectory() + "\\Resources\\Models\\medium_default.png";
            string bigCar = Directory.GetCurrentDirectory() + "\\Resources\\Models\\big_default.png";

            string smallCarNew = Directory.GetCurrentDirectory() + "\\Resources\\small.png";
            string mediumCarNew = Directory.GetCurrentDirectory() + "\\Resources\\medium.png";
            string bigCarNew = Directory.GetCurrentDirectory() + "\\Resources\\big.png";
            if (File.Exists(smallCarNew) && File.Exists(mediumCarNew) && File.Exists(bigCarNew))
            {
                File.Delete(smallCarNew);
                File.Delete(mediumCarNew);
                File.Delete(bigCarNew);

                File.Copy(smallCar, smallCarNew);
                File.Copy(mediumCar, mediumCarNew);
                File.Copy(bigCar, bigCarNew);
                pictureBox1.Image = null;
                label1.Text = "all cars have been reset to default!";
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
            }
        }
    }
}
