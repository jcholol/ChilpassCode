using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Chilpass
{
    class PasswordGenManager
    {
        public static string GeneratePassword(int size, bool hasLower, bool hasUpper, bool hasDigits, bool hasSpecialChar)
        {
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "1234567890";
            string specialChar = "!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";

            string valid = "";

            if (hasLower)
            {
                valid += lower;
            }

            if (hasUpper)
            {
                valid += upper;
            }

            if (hasDigits)
            {
                valid += digits;
            }

            if (hasSpecialChar)
            {
                valid += specialChar;
            }
            

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
