using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Utils
{
    public class PasswordEncryptor
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashOfInput = HashPassword(inputPassword);

            return hashOfInput.Equals(storedHash);
        }
    }
}
