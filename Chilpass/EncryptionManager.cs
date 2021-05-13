using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Chilpass
{

    /*
     * Creators: Jonathan Cho and Hans Wilter
     * EncryptionManager Class
     * Summary: Contains static methods for encryption functionality. Encryption and decryption.
     * 
     * Functions and methods derived + altered from:
     * https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-5.0
     */
    class EncryptionManager
    {
        public static string Encrypt(string key, string value)
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

        public static string Decrypt(string key, string encryptedText)
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
