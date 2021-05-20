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
        public GeneratePasswordForm()
        {
            InitializeComponent();
            sizeTrackBar.ValueChanged += new System.EventHandler(TrackBar_ValueChanged);
            this.Controls.Add(this.sizeTrackBar);
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
            passwordTextBox.Text = PasswordGenManager.GeneratePassword(size);

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
