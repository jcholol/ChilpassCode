using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Chilpass
{
    class HashingManager
    {
        /*
         * HashPassword method takes a string cleartext password as a paramater.
         *  Iterations is set to a million to combat brute force attacks. Slow for the user and attackers.
         *  Uses SHA512 hashing algorithm
         *  Returns the hashed string
         */
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

        /* 
         * Creates a pseudorandom salt to make a hash unique between like passwords
         */
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            // generate a salt
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static string GetSalt(byte[] theSalt)
        {
            string retVal = Encoding.Unicode.GetString(theSalt);
            return retVal;
        }
    }
}
