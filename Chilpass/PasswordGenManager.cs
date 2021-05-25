using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Chilpass
{
    class PasswordGenManager
    {
        /*
         * Creators: Jonathan Cho and Hans Wilter
         * EncryptionManager Class
         * Summary: Contains static methods for randomly generating a password
         * 
         *                                              *WARNING*
         * The GeneratePassword function has a small bias (< 0.00%) where some characters lower in 
         * value might occur more frequently. This is rare but it might occur as the 
         * RNGCryptoProvider function has a base64. Meaning that the string must be divisible evenly into 64 to create a biasless password.
         * However, this is hard to achieve as we wanted to give the users a little more freedom in selecting what they wanted
         * to generate in their passwords.
         */
        public static string GeneratePassword(int size, bool hasLower, bool hasUpper, bool hasDigits, bool hasSpecialChar)
        {
            //  variables to toggle on and off depending on user's preference
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "1234567890";
            string specialChar = "!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";

            string valid = "";

            //  adding appropriate variables to valid
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

            //  randomly generating a password by selecting random characters using 
            //  the RNGCryptoServiceProvider function.
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
