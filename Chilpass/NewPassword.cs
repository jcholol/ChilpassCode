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
        private string encryptionKey;
        private string filepath;
        public NewPassword()
        {
            InitializeComponent();
        }

        public NewPassword(string key, string file)
        {
            filepath = file;
            encryptionKey = key;
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string enteredTitle = titleTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            string encryptedTitle = FileForm.Encrypt(encryptionKey, enteredTitle);
            string encryptedPassword = FileForm.Encrypt(encryptionKey, enteredPassword);

            SQLiteConnection connection = Chilpass_Main.CreateConnection(filepath);
            Chilpass_Main.InsertEntry(connection, encryptedTitle, encryptedPassword);
            connection.Close();
            Close();
        }
    }
}
