﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class UpdateForm : Form
    {
        MainForm mainForm;
        public UpdateForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
        }
    }
}