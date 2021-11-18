using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Numbers__Efficient_
{
    class prime
    {
        //Prime until proven not prime
        private bool IsPrime { get; set; } = true;
        private string Primes { get; set; }

        public string getPrimes(int startNum, int endNum)
        {
            for (int x = startNum; x <= endNum; x++)
            {
                for (int y = 2; y < (x / 2) + 1; y++)
                {
                    if ((x % y == 0))
                    {
                        IsPrime = false;
                        break;
                    }
                }
                if (IsPrime == true)
                {
                    Primes += x + "\n";
                }
                else
                {
                    IsPrime = true;
                }

            }

            return Primes;

        }    

    }
}
