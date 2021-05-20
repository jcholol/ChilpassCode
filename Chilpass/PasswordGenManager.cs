using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Chilpass
{
    class PasswordGenManager
    {
        public static string GeneratePassword(int size)
        {

            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+/";
            StringBuilder temp = new StringBuilder();
            using (RNGCryptoServiceProvider service = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[sizeof(uint)];

                for (int i = size; i > 0; i--)
                {
                    service.GetBytes(buffer);
                    uint tempNumber = BitConverter.ToUInt32(buffer, 0);
                    temp.Append(valid[(int)(tempNumber % (uint)valid.Length)]);
                }
            }
            return temp.ToString();


        }
    }
}
