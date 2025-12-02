using CryptoJournal.Core.Interfaces.Services;

namespace CryptoJournal.Infrastructure.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        public string Hash(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPassword;
        }

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
