using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.Helpers
{
    public static class Hash
    {
        const int KEY_SIZE = 32;
        const int ITERATIONS_VALUE_SIZE = 350000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string HashPassword(string password, out byte[] stamp)
        {
            stamp = RandomNumberGenerator.GetBytes(KEY_SIZE);

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), stamp, 
                ITERATIONS_VALUE_SIZE, hashAlgorithm, KEY_SIZE);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS_VALUE_SIZE, hashAlgorithm, KEY_SIZE);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
