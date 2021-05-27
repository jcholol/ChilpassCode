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
        public EditEntryForm()
        {
            InitializeComponent();
        }

        public EditEntryForm(string title, string newFilePath, string newEncryptionKey)
        {
            InitializeComponent();
            textBoxTitle.Text = title;
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
            string enteredTitle = textBoxTitle.Text;
            string enteredPassword = textBoxConfirmPassword.Text;

            // encrypt the data in both of the feilds
            string encryptedTitle = EncryptionManager.Encrypt(encryptionKey, enteredTitle);
            string encryptedPassword = EncryptionManager.Encrypt(encryptionKey, enteredPassword);


            //  checking if the entered title already exsists (unique key)
            string data = DatabaseManager.CheckIfExists(connection, encryptedTitle);

            //  if it doesnt exist
            if (data == "")
            {
                // insert a new entry into the password file
                DatabaseManager.InsertEntry(connection, encryptedTitle, encryptedPassword);
                // close the SQLite connection 
                connection.Close();

                // close the form
                Close();
            }
            else
            {
                // ERROR an entry with that title already exists
                System.Diagnostics.Debug.WriteLine("Entry with that title already exists");
                const string msg = "An entry with that title already exists!";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            if (isShowing)
            {
                textBoxNewPassword.PasswordChar = '*';
                textBoxNewPassword.PasswordChar = '*';
                isShowing = false;
            }
            else
            {
                textBoxNewPassword.PasswordChar = '\0';
                textBoxNewPassword.PasswordChar = '\0';
                isShowing = true;
            }
        }
    }
}
