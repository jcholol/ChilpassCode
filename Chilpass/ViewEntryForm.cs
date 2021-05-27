using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chilpass
{
    public partial class ViewEntryForm : Form
    {
        public ViewEntryForm()
        {
            InitializeComponent();
        }

        public ViewEntryForm(string newTitle, string newPassword)
        {
            InitializeComponent();

            textBoxTitle.Text = newTitle.Trim();
            textBoxPassword.Text = newPassword.Trim();
            
        }

        private void buttonCopyTitle_Click(object sender, EventArgs e)
        {
            CopyControl(0);
        }

        private void buttonCopyPassword_Click(object sender, EventArgs e)
        {
            CopyControl(1);
        }

        private void CopyControl(int value)
        {
            if (value == 0)
            {
                if (textBoxTitle.Text != "")
                {
                    Clipboard.SetText(textBoxTitle.Text);
                }
            }
            else
            {
                if (textBoxPassword.Text != "")
                {
                    Clipboard.SetText(textBoxPassword.Text);
                }
                
            }
        }
    }
}
