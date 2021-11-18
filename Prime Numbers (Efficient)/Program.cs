using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Numbers__Efficient_
{
    class Program
    {
        static void Main(string[] args)
        {
            prime primeFinder = new prime();

            Console.WriteLine(primeFinder.getPrimes(2, 2000000));

            Console.ReadLine();

        }
    }
}
