﻿using System;
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
    public partial class Form4 : Form
    {
        public Form4(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }
    }
}
