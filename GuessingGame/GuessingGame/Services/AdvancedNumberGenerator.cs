using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace GuessingGame.Services
{
    public class AdvancedNumberGenerator : IRandomNumberGenerator
    {
        public int GetNext(int min, int max)
        {
            //TRUE RANDOM NUM GEN
            //New buffer to hold four bytes.
            //Bits in a byte - 8
            //bits in an integer - 32
            var buffer = new byte[4];

            //Have to bring in the RNGCryptoServiceProvider
            using (var rng = new RNGCryptoServiceProvider())
            {
                //Take the empty array and put four bytes in the array
                rng.GetBytes(buffer);
            }

            //make sure values are positive
            //0 starts at 1st element of array
            var rand = Math.Abs(BitConverter.ToInt32(buffer, 0));
            return Math.Abs(min + (rand % (max - min + 1)));
        }
    }
}