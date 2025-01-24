using Application.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string GenerateHashedPassword(string password)
        {
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);

            byte[] hashedBytes = new MD5CryptoServiceProvider().ComputeHash(passwordBytes);

            StringBuilder hashedPassword = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                hashedPassword.Append(hashedBytes[i].ToString("X2"));
            }

            return hashedPassword.ToString();
        }
    }
}
