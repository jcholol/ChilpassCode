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

namespace Chilpass
{
    public partial class NPF : Form
    {
        private static string hashed = default;
        private static byte[] salt = new byte[128 / 8];

        public NPF()
        {
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
            GenerateSalt();
            
            // generate the hash for the password
            string hashedPassword = HashPassword(masterPassword);

            hashed = hashedPassword;
            masterPassword = null; // clear the cleartext password asap
            this.Close();
        }


        /*
         * HashPassword method takes a string cleartext password as a paramater.
         *  Iterations is set to a million to combat brute force attacks. Slow for the user and attackers.
         *  Uses SHA512 hashing algorithm
         *  Returns the hashed string
         */ 
        private string HashPassword(string password)
        {

            // TODO: Leave a notifaction that it is computing hash or running so the user doesn't think its dying
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000000,
                numBytesRequested: 512 / 8));

            return hashed;
        }

        /* 
         * Creates a pseudorandom salt to make a hash unique between like passwords
         */
        private byte[] GenerateSalt()
        {
            // generate a salt
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        
        /*
         * Close the current form.
         */
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string GetHash()
        {
            return hashed;
        }

        public static string GetSalt()
        {
            string retVal = null;
            for (int i = 0; i < salt.Length; i++)
            {
                retVal += salt[i];
            }
            return retVal;
        }
    }
}
