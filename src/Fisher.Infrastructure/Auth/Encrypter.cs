using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Fisher.Core.Utilities;

namespace Fisher.Infrastructure.Auth
{
    public class Encrypter:IEncrypter
    {
        public byte[] GetHash(string password, byte[] salt)
        {
            using (var hashAlg = new HMACSHA256(salt))
            {
                return hashAlg.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
            
        }

        public byte[] GenerateRandomSalt(int length = 32)
        {
            using (var random = new RNGCryptoServiceProvider())
            {
                var salt = new byte[length];
                            random.GetNonZeroBytes(salt);
                            return salt;
            }
            
;        }
    }
}