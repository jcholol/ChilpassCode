using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chilpass
{
    public partial class OPF : Form
    {
        public OPF()
        {
            InitializeComponent();
        }

        private void OPF_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openPasswordFile = Application.OpenForms["NPF1"];
            if (openPasswordFile == null)
            {
                openPasswordFile = new FileForm();
            }
            openPasswordFile.ShowDialog();
        }
    }
}
