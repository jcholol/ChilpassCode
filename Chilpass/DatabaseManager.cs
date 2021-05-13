using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Collections;

namespace Chilpass
{
    class DatabaseManager
    {
        /*
         * ----------------------------SQLITE METHODS-------------------------------------
         *  Methods derived and altered form: https://www.codeguru.com/csharp/.net/net_data/using-sqlite-in-a-c-application.html
         */
        public static SQLiteConnection CreateConnection(string filepath)
        {
            SQLiteConnection sqliteConneciton;
            sqliteConneciton = new SQLiteConnection("Data Source=" + filepath + ";Version=3;New=True;Compress=True;");
            try
            {
                sqliteConneciton.Open();
                System.Diagnostics.Debug.WriteLine("Connection Established: " + filepath);
            }
            catch (Exception e)
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
    }
}
