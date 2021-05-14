using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Collections;

namespace Chilpass
{
    /*
     * Creators: Jonathan Cho and Hans Wilter
     * DatabaseManager Class
     * Summary: Contains static methods for database functionality. Connections, Querries, and Management.
     * 
     * Functions and methods derived + altered from:
     * https://www.codeguru.com/csharp/.net/net_data/using-sqlite-in-a-c-application.html
     */
    class DatabaseManager
    {
        /*
         * CreateConnection(string)
         * Paramaters: string (filepath)
         *      Indicates the filepath in the computer system with which to initiate a SQLIte Connection.
         * Summary: 
         *      Creates a connection with the file location passed in as an argument and returns the connection.
         */
        public static SQLiteConnection CreateConnection(string filepath)
        {
            // create connection to the filepath
            SQLiteConnection sqliteConneciton;
            sqliteConneciton = new SQLiteConnection("Data Source=" + filepath + ";Version=3;New=True;Compress=True;");
            try
            {
                sqliteConneciton.Open();
                System.Diagnostics.Debug.WriteLine("Connection Established: " + filepath);
            }
            catch (Exception e) // connection failed message
            {
                System.Diagnostics.Debug.WriteLine("Connection Failed: " + filepath);
            }
            return sqliteConneciton;
        }

        /*
         * CreateTable(SQLiteConnection)
         * Paramaters: SQLiteConnection (sqliteConnection)
         *      Indicates the SQLiteConnection to Create the database tables in.
         * Summary: 
         *      Creates the INFO and ENTRY tables in the SQLite database file passed in through SQLiteConnection.
         */
        public static void CreateTable(SQLiteConnection sqliteConnection)
        {
            // create SQLite command
            SQLiteCommand sqliteCommand;
            
            // SQLite string for creating the table INFO
            string infoTable = "CREATE TABLE INFO (Salt VARCHAR(20), Master VARCHAR(20))";

            // SQLite string for creating the table ENTRY
            string entryTable = "CREATE TABLE ENTRY (Title VARCHAR(20), Password VARCHAR(20))";

            // add a command through the connection
            sqliteCommand = sqliteConnection.CreateCommand();
            
            // add info table creation to command
            sqliteCommand.CommandText = infoTable;
            // execute command
            sqliteCommand.ExecuteNonQuery();
            
            // add entry table creation to command
            sqliteCommand.CommandText = entryTable;
            // execute command
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

        public static string CheckIfExists(SQLiteConnection sqliteConnection, string title)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = "SELECT Title FROM ENTRY WHERE Title = '" + title + "';";

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
