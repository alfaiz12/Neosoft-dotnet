﻿using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {

            lbl_result.Text = tb_Name.Text;
        }
    }
}