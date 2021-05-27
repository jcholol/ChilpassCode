using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Chilpass
{
    public partial class EditEntryForm : Form
    {
        private bool isShowing = false;
        private string filepath;
        private string encryptionKey;
        string theTitle;
        public EditEntryForm()
        {
            InitializeComponent();
        }

        public EditEntryForm(string title, string newFilePath, string newEncryptionKey)
        {
            InitializeComponent();
            theTitle = title;
            textBoxTitle.Text = theTitle;
            filepath = newFilePath;
            encryptionKey = newEncryptionKey;
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            FormManager.OpenGeneratePasswordForm();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                const string msg = "The passwords do not match.";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (textBoxNewPassword.Text == "")
            {
                const string msg = "The password field is empty, please enter a valid password!";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            UpdateEntry();
        }

        private void UpdateEntry()
        {
            // create a new SQLite connection the the file destinatiton
            SQLiteConnection connection = DatabaseManager.CreateConnection(filepath);

            // read data from the title and password text box
            string enteredTitle = textBoxTitle.Text.Trim();
            string enteredPassword = textBoxConfirmPassword.Text;

            // encrypt the data in both of the feilds
            string encryptedTitle = EncryptionManager.Encrypt(encryptionKey, enteredTitle);
            string encryptedPassword = EncryptionManager.Encrypt(encryptionKey, enteredPassword);
            DatabaseManager.UpdateEntry(connection, encryptedTitle, encryptedPassword);
            connection.Close();
            Close();
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            if (isShowing)
            {
                textBoxNewPassword.PasswordChar = '*';
                textBoxConfirmPassword.PasswordChar = '*';
                isShowing = false;
            }
            else
            {
                textBoxNewPassword.PasswordChar = '\0';
                textBoxConfirmPassword.PasswordChar = '\0';
                isShowing = true;
            }
        }
    }
}
