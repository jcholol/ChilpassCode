using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Chilpass
{
    public partial class OPF : Form
    {
        private string file;
        private byte[] salt;
        private string hash;
        public OPF()
        {
            InitializeComponent();
        }

        public OPF(string filepath, byte[] oldSalt, string oldHash)
        {
            file = filepath;
            salt = oldSalt;
            hash = oldHash;
            System.Diagnostics.Debug.WriteLine("OPF Salt Value: " + Encoding.ASCII.GetString(salt));
            InitializeComponent();
        }

        private void OPF_Load(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {}

        // submit
        private void button1_Click(object sender, EventArgs e)
        {
            bool authorized = false;
            string enteredpassword = EnterPasswordBox.Text;
            System.Diagnostics.Debug.WriteLine(enteredpassword);
            string newHash = NPF.HashPassword(enteredpassword, salt);
            //System.Diagnostics.Debug.WriteLine(newHash);
            // authorize
            if (newHash.Length == hash.Length)
            {
                if (newHash.Equals(hash))
                {
                    authorized = true;
                }
            }

            System.Diagnostics.Debug.WriteLine(newHash);
            if (authorized)
            {
                System.Diagnostics.Debug.WriteLine("Correct password");
                // decryption time
                var openPasswordFile = Application.OpenForms["FileForm"];
                if (openPasswordFile == null)
                {
                    openPasswordFile = new FileForm();
                }

                openPasswordFile.ShowDialog();

                /*
                //Read contents into a stream
                var fileStream = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                */
            }
            else
            {
                // password incorrect
                System.Diagnostics.Debug.WriteLine("Wrong password");
            }


        }
    }
}
