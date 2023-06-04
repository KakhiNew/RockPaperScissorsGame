using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    public class HCalculator
    {
        public string CalculateHMAC(string key, string[] moves)
        {
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            var hmac = new HMACSHA256(keyBytes);

            byte[] movesBytes = moves.SelectMany(Encoding.ASCII.GetBytes).ToArray();
            byte[] hashBytes = hmac.ComputeHash(movesBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
