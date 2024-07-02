using System.Security.Cryptography;

namespace UserService.Helper
{
    public class PasswordHasher
    {
        private static RNGCryptoServiceProvider rsa = new RNGCryptoServiceProvider();
        private static readonly int saltSize = 16;
        private static readonly int hashSize = 20;
        private static readonly int iterations = 1000;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[saltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            using (var key = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = key.GetBytes(hashSize);
                byte[] hashbytes = new byte[saltSize + hashSize];
                Array.Copy(salt, 0, hashbytes, 0, saltSize);
                Array.Copy(hash, 0, hashbytes, saltSize, hashSize);
                return Convert.ToBase64String(hashbytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);
            var salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            using (var key = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = key.GetBytes(hashSize);
                // Compare the computed hash with the stored hash
                for (var i = 0; i < hashSize; i++)
                {
                    if (hashBytes[i + saltSize] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}
