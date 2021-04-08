﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chilpass
{
    public partial class NPF : Form
    {
        public NPF()
        {
            InitializeComponent();
        }

        private void NPF_Load(object sender, EventArgs e)
        {

        }

        private void EnterMasterPasswordBox_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var NewPasswordFile = Application.OpenForms["NPF1"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF1();
            }
            this.Close();
            NewPasswordFile.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
