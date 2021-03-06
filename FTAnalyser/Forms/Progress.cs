﻿using FTAnalyzer.Utilities;
using System;
using System.Windows.Forms;

namespace FTAnalyzer.Forms
{
    public partial class Progress : Form
    {
        private DateTime startTime;

        public Progress(int maximum)
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maximum;
            progressBar1.Value = 0;
            startTime = DateTime.Now;
        }

        public void Update(int value)
        {
            progressBar1.Value = value;
            label1.Text = "Updated " + value + " of " + progressBar1.Maximum + " records. Please wait";
            Application.DoEvents();
        }

        private void Progress_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            SpecialMethods.SetFonts(this);
        }
    }
}
