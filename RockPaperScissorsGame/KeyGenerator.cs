using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    public class KeyGenerator
    {
        public string GenerateKey()
        {
            int keySizeInBits = 256;
            int keySizeInBytes = keySizeInBits / 8;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var key = new byte[keySizeInBytes];
                randomNumberGenerator.GetBytes(key);
                return BitConverter.ToString(key).Replace("-", "");
            }
        }

    }
}
