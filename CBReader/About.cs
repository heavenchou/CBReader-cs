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
    public partial class AboutForm : Form
    {
        MainForm mainForm;
        public AboutForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;

            if (CGlobalVal.ApplicationTitle != "CBReader") {
                // CBReader 換成 SLReader 或其它
                lbTitle.Text = lbTitle.Text.Replace("CBReader", CGlobalVal.ApplicationTitle);
            }
        }

        private void llbCBETAWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.cbeta.org/copyright.php");
        }

        private void llbCBETAEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:service@cbeta.org");
        }
    }
}
