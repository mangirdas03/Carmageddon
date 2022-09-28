using Carmageddon.Forms;
using Carmageddon.Forms.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carmageddon
{
    public partial class Form2 : Form
    {
        public Form2(HubConnection conn, Player player)
        {
            TestConn(conn, player);
            InitializeComponent();
        }

        private async Task TestConn(HubConnection conn, Player player)
        {
            await foreach (var date in conn.StreamAsync<int>("Streaming", player))
            {
                label2.Text = date.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = button1.Tag;
            var a = (sender as Button).Tag;
            var hehe = "a1";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
