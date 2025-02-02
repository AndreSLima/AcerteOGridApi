using AcerteOGrid.Domain.Security.Cryptography;
using BC = BCrypt.Net;

namespace AcerteOGrid.Infrastructure.Security
{
    internal class Cryptography : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.BCrypt.HashPassword(password);

            return passwordHash;
        }
    }
}
