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
        // array containing whether or not character sets are to be used for generation
        bool[] chars = new bool[4];

        public GeneratePasswordForm()
        {
            InitializeComponent();
            // add event to sizeTrackBar
            sizeTrackBar.ValueChanged += new System.EventHandler(TrackBar_ValueChanged);
            this.Controls.Add(this.sizeTrackBar);
            // default set all char sets to true
            SetTrue(0);
            SetTrue(1);
            SetTrue(2);
            SetTrue(3);
            // add event to checkedListBoxPassword
            checkedListBoxPassword.ItemCheck += checkedListBoxPassword_ItemChecked;
        }


        /*
         * CheckedListBoxPassword_ItemChecked
         * This method is called inthe event that an item in the checkedListBoxPassword
         * is checked. It ensures that no less than one box is checked at any given time
         * by checking the number of boxes checked and if one box is checked, ensuring that
         * the state is never changed to Unchecked.
         */
        private void checkedListBoxPassword_ItemChecked(object sender, ItemCheckEventArgs e)
        {
           // if 1 item checked and is about to be unchecked
            if (NumberChecked() == 1 && e.NewValue == CheckState.Unchecked)
            {
                // change newvalue to checked state
                e.NewValue = CheckState.Checked;
            }
        }

        /*
         * SetTrue
         * Sets the checkBox to checked state.
         */
        private void SetTrue(int index)
        {
            checkedListBoxPassword.SetItemChecked(index, true);
            
        }

        /*
         * NumberChecked
         * Counts the number of checkboxes that are currently selected
         * in the ChecklistBoxPassword.
         */
        private int NumberChecked()
        {
            int numberChecked = 0;
            for (int i = 0; i < checkedListBoxPassword.Items.Count; i++)
            {
                if (checkedListBoxPassword.GetItemChecked(i) == true)
                {
                    numberChecked++; // increment on event checkbox is checked
                }
            }
            return numberChecked;
        }


        /*
         * TrackBar_ValueChanged
         * This method is called on the event that the trackbar's value is changed.
         * Sends a message to the user depending on the lengnth of their selected 
         * password, displays the size of the password, Updates the character sets,
         * and displays the generated random password to the user.
         */
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

            // display size
            trackBarValueLabel.Text = "Size: " + (size.ToString()) + "\n" + message;

            // check the char sets
            UpdateChecked();
            // display and generate password
            passwordTextBox.Text = PasswordGenManager.GeneratePassword(size, chars[0], chars[1], chars[2], chars[3]);

        }

        /*
         * UpdateChecked()
         * Checks what character sets are currently selected by the user through
         * the checked list box.
         */
        private void UpdateChecked()
        {
            // loop through checkliastbox
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

        /*
         * CopyButton
         * This method is called when the copybutton is clicked by the user.
         * Copies the text in the password text box to the user's clipboard.
         */
        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
        }

        /*
         * There is an error with Process.Start(link) on netcore
         * The fix that is implemented below wasfound here: https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/
         * Code used from fix for opening link in default browser, rather than specific browser.
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
