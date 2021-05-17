using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Data.SQLite;
using System.Collections;

namespace Chilpass
{
    /*
     * Creators: Jonathan Cho and Hans Wilter
     * FileForm Partial Class
     * Summary: Contains methods for editing password file's information.
     *      Removing, Adding, and Viewing passwords.
     * 
     */
    public partial class FileForm : Form
    {
        // authorized view
        private string encryptionKey = String.Empty;
        private string filepath = String.Empty;
        private ArrayList encryptedArray;

        public FileForm()
        {
            InitializeComponent();
        }

        public FileForm(string encKey, string file)
        {
            filepath = file;
            encryptionKey = encKey;
            InitializeComponent();
            LoadListView();
        }

        private void RemovePasswordButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string title = listView.SelectedItems[0].Text;
                int index = listView.Items.IndexOf(listView.SelectedItems[0]);
                index = index * 2;
                System.Diagnostics.Debug.WriteLine("Index: " + index);

                const string msg = "Are you sure you want to delete this password entry? \nOnce it is deleted, it CANNOT be recovered.";
                const string boxTitle = "Are you sure?";

                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string temp = (string) encryptedArray[index];
                    System.Diagnostics.Debug.WriteLine("Value get title: " + temp);
                    SQLiteConnection connection = DatabaseManager.CreateConnection(filepath);
                    DatabaseManager.RemoveEntry(connection, temp);
                    connection.Close();
                    LoadListView();
                }
            }
            else
            {
                const string msg = "Select an item from the list to remove.";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            var NewPassword = Application.OpenForms["NewPassword"];
            if (NewPassword == null)
            {
                NewPassword = new NewPassword(encryptionKey, filepath);
            }
            NewPassword.ShowDialog();
            LoadListView();
        }

        public void LoadListView()
        {
            listView.Items.Clear();
            SQLiteConnection sqliteConnection = DatabaseManager.CreateConnection(filepath);
            encryptedArray = DatabaseManager.ReadEntries(sqliteConnection);
            
            for (int i = 0; i < encryptedArray.Count - 1; i++)
            {
                string title = EncryptionManager.Decrypt(encryptionKey, (string)encryptedArray[i]);
                string pass = EncryptionManager.Decrypt(encryptionKey, (string)encryptedArray[i+1]);

                ListViewItem item = new ListViewItem(title);
                item.SubItems.Add(pass);
                listView.Items.AddRange(new ListViewItem[] { item });
                i++;
            }
            sqliteConnection.Close();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * Referenced: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-5.0
         */
        /*
         * -------------- NOTE ---------------
         *      Moved to EncryptionManager
         * -----------------------------------
        public static string Encrypt(string key, string value)
        {
            byte[] iv = new byte[16];
            byte[] encryptedText; 

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream mEncrypt = new MemoryStream())
                {
                    using (CryptoStream cEncrypt = new CryptoStream(mEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sEncrypt = new StreamWriter(cEncrypt))
                        {
                            sEncrypt.WriteLine(value);
                        }
                        encryptedText = mEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedText);
        }

        public static string Decrypt(string key, string encryptedText)
        {
            
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                //aes.Padding = PaddingMode.None;
                aes.KeySize = 128;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream mEncrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream cEncrypt = new CryptoStream(mEncrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sEncrypt = new StreamReader(cEncrypt))
                        {
                            return sEncrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        */
    }
}
