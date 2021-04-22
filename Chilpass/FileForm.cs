using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Chilpass
{
    public partial class FileForm : Form
    {
        // authorized view
        private string encryptionKey = String.Empty;

        public FileForm()
        {
            InitializeComponent();
        }

        public FileForm(string encKey, string file)
        {
            encryptionKey = encKey;
            InitializeComponent();
        }

        private void RemovePasswordButton_Click(object sender, EventArgs e)
        {
            const string msg = "Are you sure you want to delete this password entry? \nOnce it is deleted, it CANNOT be recovered.";
            const string boxTitle = "Are you sure?";

            var result = MessageBox.Show(msg, boxTitle, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

            }
        }

        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            string title = "temp";
            string password = "temp1";
            string encryptedTitle = Encrpyt(encryptionKey, title);
            string ecryptedPassword = Encrpyt(encryptionKey, password);


            System.Diagnostics.Debug.WriteLine("Encrypted title: " + encryptedTitle);
            System.Diagnostics.Debug.WriteLine("Encrypted password: " + ecryptedPassword);

            string decryptTitle = Decrypt(encryptionKey, encryptedTitle);
            string decryptPass = Decrypt(encryptionKey, ecryptedPassword);
            System.Diagnostics.Debug.WriteLine("Decrypted title: " + decryptTitle);
            System.Diagnostics.Debug.WriteLine("Decrypted password: " + decryptPass);
        }

        /*
         * Referenced: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-5.0
         */
        public string Encrpyt(string key, string value)
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

        public string Decrypt(string key, string encryptedText)
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
    }
}
