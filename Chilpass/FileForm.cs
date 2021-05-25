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
     * Contains methods for editing password file's information.
     *      Removing, Adding, and Viewing passwords.
     * FileForm is an authorized view, meaning that if a user has gotten to this stage they
     * have entered the masterpassword associated with the file and aare now authorized to 
     * view the file's contents.
     */
    public partial class FileForm : Form
    {
        // authorized view
        private string encryptionKey = String.Empty;
        private string filepath = String.Empty;

        // stores entries
        private ArrayList encryptedArray;


        /*
         * Default Constructor
         */
        public FileForm()
        {
            InitializeComponent();
        }

        /*
         * FileFomr(string, string)
         * Paramaters: 
         *      string (encKey) - Enckey passed from previous form for use in Decrypting.
         *      string (file) - The file currently accessed.
         */
        public FileForm(string encKey, string file)
        {
            filepath = file;
            encryptionKey = encKey;
            InitializeComponent();
            // loads the listviewtree with entries on load
            LoadListView();
        }

        /*
         * RemovePasswordButton_Click
         * On the event that the RemovePasswordButton is clicked, this method
         * is called.
         * Removes the entry that the user selected from the ListViewTree. If 
         * no entry is selected, prompt the user to select an entry. On the event that
         * a user has selected an entry, confirm their choice for deletion.
         */
        private void RemovePasswordButton_Click(object sender, EventArgs e)
        {
            // ensure the user has selected an item
            if (listView.SelectedItems.Count > 0)
            {
                //string title = listView.SelectedItems[0].Text;
                
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
                // prompt user to select an item through a message box
                const string msg = "Select an item from the list to remove.";
                const string boxTitle = "Error.";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /*
         * NewPasswordButton_Click
         * On the event that the NewPasswordButton is clicked, this method
         * is called.
         * Opens the NewPassword Form to the user, after the form is closed 
         * updates the listview tree in the event that a password was added.
         */
        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            FormManager.OpenNewPasswordForm(encryptionKey, filepath);
            LoadListView();
        }

        /*
         * LoadListView
         * Clears the listview tree of the current items displaayed. Then this
         * method decrypts the encryptedArray entry by entry to be displayed so 
         * that the password file is never altered to show clear text passwords.
         */
        public void LoadListView()
        {
            // clear previous listview
            listView.Items.Clear();
            SQLiteConnection sqliteConnection = DatabaseManager.CreateConnection(filepath);
            encryptedArray = DatabaseManager.ReadEntries(sqliteConnection);
            
            for (int i = 0; i < encryptedArray.Count - 1; i++)
            {
                // decrypt title and password
                string title = EncryptionManager.Decrypt(encryptionKey, (string)encryptedArray[i]);
                string pass = EncryptionManager.Decrypt(encryptionKey, (string)encryptedArray[i+1]);

                // set items into listview
                ListViewItem item = new ListViewItem(title);
                item.SubItems.Add(pass);
                listView.Items.AddRange(new ListViewItem[] { item });
                i++;
            }
            sqliteConnection.Close();
        }

        /*
         * Generated by Windows Forms
         */
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
