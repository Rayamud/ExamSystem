using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsSecurtyHash
    {
        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            //using (SHA256 sha256 = SHA256.Create())
            //{
            //    // Compute the hash value from the UTF-8 encoded input string
            //    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


            //    // Convert the byte array to a lowercase hexadecimal string
            //    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            //}

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 formats as hexadecimal
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            // Hash the input password using the same method
            string inputHash = ComputeHash(inputPassword);

            // Compare the computed hash with the stored hash
            StringComparer comparer = StringComparer.OrdinalIgnoreCase; // Case-insensitive comparison

            return comparer.Compare(inputHash, storedHash) == 0;
        }
    }
}
