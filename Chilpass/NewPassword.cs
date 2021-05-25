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
    public partial class NewPassword : Form
    {
        /*
         * Global variables
         */
        private string encryptionKey;
        private string filepath;

        /*
         * Creators: Jonathan Cho and Hans Wilter
         * NewPassword Partial Class
         * Summary: Contains methods for events trigged on New Password button after opening a file form. 
         * Handles SQL connection, encryption and hashing
         */
        public NewPassword()
        {
            InitializeComponent();
        }

        /*
         * Constructor for NewPassword form data passing. 
         * Paramaters: string key indicating the encryption key to encrypt the new password with
         *              string file the file associated with the encryption key to store the password
         */
        public NewPassword(string key, string file)
        {
            filepath = file;
            encryptionKey = key;
            InitializeComponent();
        }

        /*
         * submitButton_Click 
         * On the event that the submitButton is clicked, this method is called.
         * when the button is clicked by the user, the data is read from the textbox, 
         * encrypted, and stored in the password file.
         */
        private void submitButton_Click(object sender, EventArgs e)
        {
            // create a new SQLite connection the the file destinatiton
            SQLiteConnection connection = DatabaseManager.CreateConnection(filepath);

            // read data from the title and password text box
            string enteredTitle = titleTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            //  if the entries are empty
            if (enteredTitle == "" && enteredPassword == "")
            {
                const string msg = "The title and password fields are empty, please enter a valid title and password!";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            //  if the entered title is empty
            else if (enteredTitle == "")
            {
                const string msg = "The title field is empty, please enter a valid title!";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            //  if the entered password is empty
            else if (enteredPassword == "")
            {
                const string msg = "The password field is empty, please enter a valid password!";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

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
    }
}
