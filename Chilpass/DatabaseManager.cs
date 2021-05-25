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
         * Creates a connection with the file location passed in as an argument and returns the connection.
         */
        public static SQLiteConnection CreateConnection(string filepath)
        {
            SQLiteConnection sqliteConneciton;

            // create connection to the filepath
            sqliteConneciton = new SQLiteConnection("Data Source=" + filepath + ";Version=3;New=True;Compress=True;");
            try
            {
                sqliteConneciton.Open(); // open the connection with the file
                System.Diagnostics.Debug.WriteLine("Connection Established: " + filepath);
            }
            catch (Exception e) 
            {
                // connection failed message
                System.Diagnostics.Debug.WriteLine("Connection Failed: " + filepath);
            }
            return sqliteConneciton;
        }

        /*
         * CreateTable(SQLiteConnection)
         * Paramaters: SQLiteConnection (sqliteConnection)
         *      Indicates the SQLiteConnection to Create the database tables in.
         * Creates the INFO and ENTRY tables in the SQLite database file passed in through SQLiteConnection.
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

        /*
         * InsertAuthData(SQLiteConnection, string, string)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         *      string (salt) - Encrypted salt value to be stored in the Salt Column of the INFO table.
         *      string (hash) - Encrypted hash value to be stored in the Hash Column of the INFO table.
         * Inserts the salt and hash data into the INFO tables in a given password file indicted
         *  through the SQLiteConnection argument.
         */
        public static void InsertAuthData(SQLiteConnection sqliteConnection, string salt, string hash)
        {
            SQLiteCommand sqliteCommand;
            // create a SQLite command
            sqliteCommand = sqliteConnection.CreateCommand();
            // SQLIte syntax for inserting salt and hash data into the INFO table
            sqliteCommand.CommandText = "INSERT INTO INFO (Salt, Master) VALUES ('" + salt + "', '" + hash + "');";
            // execute the command
            sqliteCommand.ExecuteNonQuery();
        }

        /*
         * InsertEntry(SQLiteConnection, string, string)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         *      string (title) - Encrypted title value to be stored in the Title Column of the ENTRY table.
         *      string (password) - Encrypted password value to be stored in the Password Column of the ENTRY table.
         * Inserts the encrypted title and password data into the INFO tables in a given password file indicted
         * through the SQLiteConnection argument.
         */
        public static void InsertEntry(SQLiteConnection sqliteConnection, string title, string password)
        {
            SQLiteCommand sqlitecommand;
            // create a SQLite command
            sqlitecommand = sqliteConnection.CreateCommand();
            // SQLIte syntax for inserting title and password data into the ENTRY table
            sqlitecommand.CommandText = "INSERT INTO ENTRY (Title, Password) VALUES ('" + title + "', '" + password + "')";
            // execute the command
            sqlitecommand.ExecuteNonQuery();
        }

        /*
         * RemoveEntry(SQLiteConnection, string)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         *      string (title) - Encrypted title value to be found and removed from the ENTRY table.
         * Removes the selected title and password data for the given title passed as an argument from the 
         * ENTRY Table in the database.
         */
        public static void RemoveEntry(SQLiteConnection sqliteConnection, string title)
        {
            SQLiteCommand sqlitecommand;
            // create SQLite command
            sqlitecommand = sqliteConnection.CreateCommand();
            // SQLite syntax for deleting a row from the ENTRY table where the title equals the argument
            sqlitecommand.CommandText = "DELETE FROM ENTRY WHERE Title = '" + title + "';";
            // execute the command
            sqlitecommand.ExecuteNonQuery();
        }

        /*
         * ReadSalt(SQLiteConnection)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         * Querries the database, selecting the Salt from the INFO table in the database. 
         */
        public static string ReadSalt(SQLiteConnection sqliteConnection)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            
            // SQLite syntax for getting the Salt from the INFO table
            sqliteCommand.CommandText = "SELECT Salt FROM INFO";

            string myreader = ""; // string to store results

            // execute the command, read and store the data into myreader variable
            sqliteDataReader = sqliteCommand.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                myreader = sqliteDataReader.GetString(0);
            }
            return myreader;
        }

        /*
         * ReadSalt(SQLiteConnection)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         * Querries the database, selecting the Master from the INFO table in the database. 
         */
        public static string ReadHash(SQLiteConnection sqliteConnection)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();

            // SQLite syntax for getting the Salt from the INFO table
            sqliteCommand.CommandText = "SELECT Master FROM INFO";

            string myreader = ""; // string to store results

            // execute the command, read and store the data into myreader variable
            sqliteDataReader = sqliteCommand.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                myreader = sqliteDataReader.GetString(0);
                System.Diagnostics.Debug.WriteLine(myreader);
            }
            return myreader;
        }

        /*
         * CheckIfExists(SQLiteConnection, string)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         *      string (title) - Indicates the title of the entry in question.
         * Querries the database, selecting the Master from the INFO table in the database. 
         */
        public static string CheckIfExists(SQLiteConnection sqliteConnection, string title)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();

            // SQLite syntax for getting the Title from the ENTRY table, the Title equals the title argument
            sqliteCommand.CommandText = "SELECT Title FROM ENTRY WHERE Title = '" + title + "';";

            string myreader = ""; // string to store results

            // execute the command, read and store the data into myreader variable
            sqliteDataReader = sqliteCommand.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                myreader = sqliteDataReader.GetString(0);
            }
            // if the resulting value is empty, the row does not exist
            return myreader;
        }

        /*
         * CheckIfExists(SQLiteConnection)
         * Paramaters: 
         *      SQLiteConnection (sqliteConnection) - Indicates the SQLiteConnection to interact with.
         * Querries the database, selecting all the values stored in the ENTRY table and returning the 
         * result as an ArrayList.
         */
        public static ArrayList ReadEntries(SQLiteConnection sqliteConnection)
        {
            // create array list to store returned results
            ArrayList array = new ArrayList();
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = sqliteConnection.CreateCommand();
            // SQLite syntax for getting all of the values form the ENTRY Table
            sqliteCommand.CommandText = "SELECT * FROM ENTRY";

            sqliteDataReader = sqliteCommand.ExecuteReader();
            
            // store both columns into the arraylist
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
