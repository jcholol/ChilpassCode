using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace Chilpass
{
    public partial class NPF : Form
    {
        private static string hashed = default;
        private static byte[] salt = new byte[128 / 8];
        private string filePath;

        public NPF()
        {
            InitializeComponent();
        }

        public NPF(string filepath)
        {
            filePath = filepath;
            InitializeComponent();
        }

        private void NPF_Load(object sender, EventArgs e)
        {}

        // label
        private void EnterMasterPasswordBox_Click(object sender, EventArgs e)
        {}

        /*
         * Save the file. 
         */
        private void saveButton_Click(object sender, EventArgs e)
        {
            // get the enetered password
            string masterPassword = EnterPasswordBox.Text;
            
            // generate a salt value
            byte[] theSalt = HashingManager.GenerateSalt();

            /*
             * Old Code
            // generate the hash for the password
            string hashedPassword = PBKDF2(masterPassword, 10000);
            */

            /*
             * New Code
             */
            // generate the encryption key value, this is derived
            string encryptionKey = HashingManager.PBKDF2(masterPassword, theSalt, 10000);


            // generate the hash for the password, store this in the file
            string hashKey = HashingManager.PBKDF2(encryptionKey, theSalt, 1);

            /*
             * End
             */

            hashed = hashKey;
            masterPassword = null; // clear the cleartext password asap

            SQLiteConnection sqliteConnection;
            sqliteConnection = DatabaseManager.CreateConnection(filePath);
            DatabaseManager.CreateTable(sqliteConnection);

            // Ensure data is encrpyted using encryption key
            DatabaseManager.InsertAuthData(sqliteConnection, HashingManager.GetSaltByteToString(theSalt), hashKey);

            FormManager.OpenPasswordFileForm(encryptionKey, filePath);

            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*
         * -------------- NOTE ---------------
         *      Moved to HashingManager
         * -----------------------------------
         * 
         * 
         * HashPassword method takes a string cleartext password as a paramater.
         *  Iterations is set to a million to combat brute force attacks. Slow for the user and attackers.
         *  Uses SHA512 hashing algorithm
         *  Returns the hashed string
         */
        /*
        public static string PBKDF2(string password, int iterations)
        {
            // TODO: Leave a notifaction that it is computing hash or running so the user doesn't think its dying
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterations, // increase later
                numBytesRequested: 128 / 8));

            System.Diagnostics.Debug.WriteLine("Hash: " + hashed);
            return hashed;
        }

        public static string PBKDF2(string password, byte[] theSalt, int iterations)
        {

            // TODO: Leave a notifaction that it is computing hash or running so the user doesn't think its dying
            
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: theSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterations, // increase later
                numBytesRequested: 128 / 8));

            return hashed;
        }
        */


        /* 
         * Creates a pseudorandom salt to make a hash unique between like passwords
         */
        /*
        private byte[] GenerateSalt()
        {
            // generate a salt
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        */

        /*
         * Close the current form.
         */


        /*
        public static string GetHash()
        {
            return hashed;
        }

        public static string GetSalt()
        {
            string retVal = Encoding.Unicode.GetString(salt);
            return retVal;
        }
        */
    }
}
