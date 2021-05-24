using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Chilpass
{
    public partial class GeneratePasswordForm : Form
    {
        bool[] chars = new bool[4];

        public GeneratePasswordForm()
        {
            InitializeComponent();
            sizeTrackBar.ValueChanged += new System.EventHandler(TrackBar_ValueChanged);
            this.Controls.Add(this.sizeTrackBar);
            SetTrue(0);
            SetTrue(1);
            SetTrue(2);
            SetTrue(3);
            checkedListBoxPassword.ItemCheck += checkedListBoxPassword_ItemChecked;
        }


        private void checkedListBoxPassword_ItemChecked(object sender, ItemCheckEventArgs e)
        {
           
            if (NumberChecked() == 1 && e.NewValue == CheckState.Unchecked)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void SetTrue(int index)
        {
            checkedListBoxPassword.SetItemChecked(index, true);
            
        }

        private int NumberChecked()
        {
            int numberChecked = 0;
            for (int i = 0; i < checkedListBoxPassword.Items.Count; i++)
            {
                if (checkedListBoxPassword.GetItemChecked(i) == true)
                {
                    numberChecked++;
                }
            }
            return numberChecked;
        }

        

        private void TrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            int size = sizeTrackBar.Value;
            string message = "";
            if (size < 8)
            {
                message = "Weak Password";
                trackBarValueLabel.ForeColor = Color.Red;
            }
            else if (size < 12)
            {
                message = "Good Password";
                trackBarValueLabel.ForeColor = Color.Orange;
            }
            else
            {
                message = "Amazing Password";
                trackBarValueLabel.ForeColor = Color.Green;
            }

            trackBarValueLabel.Text = "Size: " + (size.ToString()) + "\n" + message;

            UpdateChecked();
            passwordTextBox.Text = PasswordGenManager.GeneratePassword(size, chars[0], chars[1], chars[2], chars[3]);

        }

        private void UpdateChecked()
        {
            for (int i = 0; i < checkedListBoxPassword.Items.Count; i++)
            {
                if (checkedListBoxPassword.GetItemChecked(i) == true)
                {
                    chars[i] = true;
                }
                else
                {
                    chars[i] = false;
                }
            }
        } 

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
        }

        /*
         * Error with Process.Start(link) on netcore
         * Fix found here: https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/
         * Code used from fix for opening link in default browser.
         */

        private void linkLabelPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://howsecureismypassword.net/";
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
