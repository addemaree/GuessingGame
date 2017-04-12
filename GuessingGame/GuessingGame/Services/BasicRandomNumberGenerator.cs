using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessingGame.Services
{
    public class BasicRandomNumberGenerator : IRandomNumberGenerator
    {
        public int GetNext(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}