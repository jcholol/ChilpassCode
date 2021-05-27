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
     * 
     * Source - Microsoft Documentation, sorting listview
     * https://docs.microsoft.com/en-us/troubleshoot/dotnet/csharp/sort-listview-by-column
     */
    public partial class FileForm : Form
    {
        // authorized view
        private string encryptionKey = String.Empty;
        private string filepath = String.Empty;

        // stores entries
        private ArrayList encryptedArray;

        private ListViewColumnSorter lvwColumnSorter;

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
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = lvwColumnSorter;
            // loads the listviewtree with entries on load
            LoadListView();
            listView.ColumnWidthChanging += (listView_ColumnWidthChanging);
            listView.DoubleClick += listView_DoubleClick;
            listView.MouseClick += listView_MouseClick;
            listView.ColumnClick += listView_ColumnClick;
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            toolStripMenuItemEdit.Click += toolStripMenuItemEdit_Click;
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;

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
            Remove();
        }

        private void Remove()
        {
            // ensure the user has selected an item
            if (listView.SelectedItems.Count > 0)
            {
                string title = listView.SelectedItems[0].Text.Trim();
                string encryptedTitle = EncryptionManager.Encrypt(encryptionKey, title);


                //int index = listView.Items.IndexOf(listView.SelectedItems[0]);
                //index = index * 2;
                //System.Diagnostics.Debug.WriteLine("Index: " + index);

                const string msg = "Are you sure you want to delete this password entry? \nOnce it is deleted, it CANNOT be recovered.";
                const string boxTitle = "Are you sure?";

                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //string temp = (string)encryptedArray[index];
                    
                    SQLiteConnection connection = DatabaseManager.CreateConnection(filepath);
                    DatabaseManager.RemoveEntry(connection, encryptedTitle);
                    connection.Close();
                    LoadListView();
                }
            }
            else
            {
                // prompt user to select an item through a message box
                const string msg = "Select an item from the list to remove.";
                const string boxTitle = "Error";
                var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /*
         * listView_ColumnWidthChanging
         * This method is called when the column width for the listView is changed.
         * This method ensures that the width of the columns in the listView remain static,
         * takes the event and assigns the defualt width to the newWidth event.
         */
        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // ensure width stays the same
            e.NewWidth = this.listView.Columns[e.ColumnIndex].Width;
            // cancel the event that is happening
            e.Cancel = true;

        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            string title = listView.SelectedItems[0].Text;
            string pass = listView.SelectedItems[0].SubItems[1].Text;
            FormManager.OpenViewEntryForm(title, pass);
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView.FocusedItem;
                if (item != null && item.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {}

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            string title = listView.SelectedItems[0].Text;
            string pass = listView.SelectedItems[0].SubItems[1].Text;
            FormManager.OpenViewEntryForm(title, pass);
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            string title = listView.SelectedItems[0].Text;
            string pass = listView.SelectedItems[0].SubItems[1].Text;
            FormManager.OpenEditEntryForm(title, filepath, encryptionKey);
            LoadListView();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string text = textBoxSearch.Text;
            string encryptedText = EncryptionManager.Encrypt(encryptionKey, text);
            SQLiteConnection connection = DatabaseManager.CreateConnection(filepath);
            string result = DatabaseManager.CheckIfExists(connection, encryptedText);
            if (result == "")
            {
                // prompt user to select an item through a message box
                const string msg = "No entries with that title were found!\nEnsure that the title entered matches the desired entry completely.";
                const string boxTitle = "Error";
                var temp = MessageBox.Show(msg, boxTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string encryptedPassword = DatabaseManager.GetPassword(connection, encryptedText);

            string password = EncryptionManager.Decrypt(encryptionKey, encryptedPassword);

            FormManager.OpenViewEntryForm(text, password);
            
        }
    }
}
