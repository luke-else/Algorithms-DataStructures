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
            int startNum = 2;
            int maxNum = Convert.ToInt32(Console.ReadLine());
            bool isPrime = true;
            List<int> primeList = new List<int>();

            for (int x = startNum; x <= maxNum; x++)
            {
                for (int y = 2; y < (x / 2) + 1; y++)
                {
                    if ((x % y == 0))
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true)
                {
                    primeList.Add(x);
                }
                else
                {
                    isPrime = true;
                }
                
            }

            foreach (var item in primeList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
