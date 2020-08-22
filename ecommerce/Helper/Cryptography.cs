using CryptoHelper;

namespace ecommerce.Helper
{
    public static class Cryptography
    {
        // Method for hashing the password
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Method to verify the password hash against the given password
        public static bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
