﻿using System;
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
        private string encryptionKey;
        private string filepath;
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
         * submitButton_Click when the button is clicked by the user, the data is read from the textboxes, 
         *  ecnrypted, and stored in the password file.
         */
        private void submitButton_Click(object sender, EventArgs e)
        {
            // create a new SQLite connection the the file destinatiton
            SQLiteConnection connection = DatabaseManager.CreateConnection(filepath);

            // read data from the title and password text box
            string enteredTitle = titleTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            

            // encrypt the data in both of the feilds
            string encryptedTitle = EncryptionManager.Encrypt(encryptionKey, enteredTitle);
            string encryptedPassword = EncryptionManager.Encrypt(encryptionKey, enteredPassword);

            string data = DatabaseManager.CheckIfExists(connection, encryptedTitle);

            if (data == "")
            {
                // insert a new entry into the password file
                DatabaseManager.InsertEntry(connection, encryptedTitle, encryptedPassword);
            }
            else
            {
                // ERROR an entry with that title already exists
                System.Diagnostics.Debug.WriteLine("Entry already exists");
            }
            
            // close the SQLite connection 
            connection.Close();

            // close the form
            Close();
        }
    }
}
