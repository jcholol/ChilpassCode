using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Collections;


namespace Chilpass
{
    /*
     * Creators: Jonathan Cho and Hans Wilter
     * Chilpass_Main Partial Class
     * Summary: Contains methods for event triggers from the Chilpass_Main form.
     * 
     */
    public partial class Chilpass_Main : Form
    {

        public Chilpass_Main()
        {
            InitializeComponent();
        }

        private void NewPasswordFileButton_Click(object sender, EventArgs e)
        {
            var saveDatabaseFile = new SaveFileDialog();
            saveDatabaseFile.Filter = "Database Files (*.db) | *.db";
            saveDatabaseFile.Title = "Save a Database File";
            saveDatabaseFile.FileName = "NewPasswordFile";
            string filepath = null;

            if (saveDatabaseFile.ShowDialog() == DialogResult.OK)
            {
                //System.IO.FileStream myStream = (System.IO.FileStream)saveDatabaseFile.OpenFile();
                filepath = saveDatabaseFile.FileName;
            }

            var NewPasswordFile = Application.OpenForms["NPF"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF(filepath);
            }
            NewPasswordFile.ShowDialog();

            
        }

        private void OpenPasswordFileButton_Click(object sender, EventArgs e)
        {
            //var fileContent = string.Empty;
            var filePath = string.Empty;

            //bool authorized = false;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Database Files (*.db) | *.db";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get path of file
                    filePath = openFileDialog.FileName;
                }
            }

            if (filePath != "")
            {
                string oldSalt = String.Empty;
                string oldHash = String.Empty;

                SQLiteConnection sqliteConnection;
                sqliteConnection = DatabaseManager.CreateConnection(filePath);
                oldSalt = DatabaseManager.ReadSalt(sqliteConnection);
                oldHash = DatabaseManager.ReadHash(sqliteConnection);
                sqliteConnection.Close();

                var openPasswordFile = Application.OpenForms["OPF"];
                if (openPasswordFile == null)
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(oldSalt);
                    openPasswordFile = new OPF(filePath, bytes, oldHash);
                }

                openPasswordFile.ShowDialog();
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            var help = Application.OpenForms["Help"];
            if (help == null)
            {
                help = new Help();
            }
            help.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


        private void GeneratePasswordButton_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /*
        
         * -------------- NOTE ---------------
         *         Moved to FormManager
         * -----------------------------------

        // Open the FileForm form and close the current form.
        
        public static void OpenPasswordFileForm(string encrypKey, string file)
        {
            var NewPasswordFile = Application.OpenForms["FileForm"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new FileForm(encrypKey, file);
            }
            NewPasswordFile.ShowDialog();
        }
        */

        /*
         * -------------- NOTE ---------------
         *      Moved to DatabaseManager
         * -----------------------------------
         * 
         * 
        public static SQLiteConnection CreateConnection(string filepath)
        {
            SQLiteConnection sqliteConneciton;
            sqliteConneciton = new SQLiteConnection("Data Source=" + filepath + ";Version=3;New=True;Compress=True;");
            try
            {
                sqliteConneciton.Open();
                System.Diagnostics.Debug.WriteLine("Connection Established: " + filepath);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Connection Failed: " + filepath);
            }
            return sqliteConneciton;
        }

        public static void CreateTable(SQLiteConnection sqliteConnection)
        {
            SQLiteCommand sqliteCommand;
            string infoTable = "CREATE TABLE INFO (Salt VARCHAR(20), Master VARCHAR(20))";
            string entryTable = "CREATE TABLE ENTRY (Title VARCHAR(20), Password VARCHAR(20))";
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = infoTable;
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = entryTable;
            sqliteCommand.ExecuteNonQuery();
        }

        public static void InsertAuthData(SQLiteConnection sqliteConnection, string salt, string hash)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO INFO (Salt, Master) VALUES ('" + salt + "', '" + hash + "');";
            sqliteCommand.ExecuteNonQuery();
        }

        public static void InsertEntry(SQLiteConnection sqliteConnection, string title, string password)
        {
            SQLiteCommand sqlitecommand;
            sqlitecommand = sqliteConnection.CreateCommand();
            sqlitecommand.CommandText = "INSERT INTO ENTRY (Title, Password) VALUES ('" + title + "', '" + password + "')";
            sqlitecommand.ExecuteNonQuery();
        }

        public static void RemoveEntry(SQLiteConnection sqliteConnection, string title)
        {
            SQLiteCommand sqlitecommand;
            sqlitecommand = sqliteConnection.CreateCommand();
            sqlitecommand.CommandText = "DELETE FROM ENTRY WHERE Title = '" + title + "';";
            sqlitecommand.ExecuteNonQuery();
        }

        public static string ReadSalt(SQLiteConnection sqliteConnection)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = "SELECT Salt FROM INFO";

            string myreader = "";
            sqliteDataReader = sqliteCommand.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                myreader = sqliteDataReader.GetString(0);
                System.Diagnostics.Debug.WriteLine(myreader);
            }
            return myreader;
        }

        public static string ReadHash(SQLiteConnection sqliteConnection)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = "SELECT Master FROM INFO";

            string myreader = "";
            sqliteDataReader = sqliteCommand.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                myreader = sqliteDataReader.GetString(0);
                System.Diagnostics.Debug.WriteLine(myreader);
            }
            return myreader;
        }

        public static ArrayList ReadEntries(SQLiteConnection sqliteConnection)
        {
            ArrayList array = new ArrayList();
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM ENTRY";

            sqliteDataReader = sqliteCommand.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                string myreader = sqliteDataReader.GetString(0);
                array.Add(myreader);
                myreader = sqliteDataReader.GetString(1);
                array.Add(myreader);
            }
            sqliteConnection.Close();
            return array;
        }
        */

        /*
        * -----------------OLD Version, two file system. Methods to open and create text files-----------------
        */
        // old TXT version
        /*
        private void OpenTxtVersion(string filepath)
        {
            string textFile = filepath.Substring(0, filepath.Length - 2);
            textFile += "txt";

            if (File.Exists(textFile))
            {
                StreamReader sr = new StreamReader(textFile);
                string associatedFile = sr.ReadLine();
                string oldSalt = sr.ReadLine();
                string oldHash = sr.ReadLine();
                sr.Close();



                var openPasswordFile = Application.OpenForms["OPF"];
                if (openPasswordFile == null)
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(oldSalt);
                    openPasswordFile = new OPF(associatedFile, bytes, oldHash);
                }

                openPasswordFile.ShowDialog();
            }
            else
            {
                // some error
            }
        }

        // old txt version
        private void CreateTxtVersion(string filepath)
        {
            string textFile = filepath.Substring(0, filepath.Length - 2);
            textFile += "txt";

            if (!File.Exists(filepath))
            {
                // ATT TO INFO
                File.Create(filepath).Close();
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(filepath);
                    sw.WriteLine(NPF.GetSalt());
                    sw.WriteLine(NPF.GetHash());
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(filepath);
                    sw.WriteLine(NPF.GetSalt());
                    sw.WriteLine(NPF.GetHash());
                }
            }
        }
        */
    }
}
