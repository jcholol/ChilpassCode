using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chilpass
{
    public partial class NPF1 : Form
    {
        public NPF1()
        {
            InitializeComponent();
        }

        private void RemovePasswordButton_Click(object sender, EventArgs e)
        {
            const string msg = "Are you sure you want to delete this password entry? \nOnce it is deleted, it CANNOT be recovered.";
            const string boxTitle = "Are you sure?";

            var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
            }
        }
    }
}
