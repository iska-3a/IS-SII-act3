using System.Security.Cryptography;

namespace InventoryManagementSystem
{
    public static class PasswordSecurity
    {
        private const int Iterations = 100_000;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, 32);
            return $"PBKDF2${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                string[] parts = storedHash.Split('$');
                if (parts.Length != 4 || parts[0] != "PBKDF2")
                    return false;

                int iterations = int.Parse(parts[1]);
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] original = Convert.FromBase64String(parts[3]);

                byte[] attempt = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, original.Length);
                return CryptographicOperations.FixedTimeEquals(attempt, original);
            }
            catch
            {
                return false;
            }
        }
    }
}
