using System;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            CommonAlgorithmsInProgramming.Method();
        }
    }

    class CommonAlgorithmsInProgramming
    {
        public static void Method()
        {
            long number = GCD(60, 96); // should be 12
            Console.WriteLine(number);
            Console.WriteLine(GCD(20, 8)); // should be 4
            Console.WriteLine(GCD(8, 8)); // should be 8
            Console.WriteLine(GCD(11, 13)); // should be 1
            Console.WriteLine(GCD(13, 11)); // must be 1
        }

        static long GCD(long a, long b) // Euclid's algorithm.              // a = 11 // b = 13
        {
            long temp;
            while (b != 0)                                                  // 13 != 0          // 11 != 0         // 2 != 0         // 1 != 0
            {
                temp = a;                                                   // temp = 11        // temp = 13       // temp = 11      // temp = 2
                a = b; // we return a as we set a equal to b ahead of time  // a = 13           // a = 11          // a = 2          // a = 1
                b = temp % b; // or `b = temp % a`                          // b = 11 % 13 = 11 // b = 13 % 11 = 2 // b = 11 % 2 = 1 // b = 2 % 1 = 0
            }
            return a;
        }
    }
}