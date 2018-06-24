using System;
using System.Numerics;

namespace BigFactoriel
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            BigInteger factoriel = 1;

            for (int num = 1; num <= number; num++)
            {
                factoriel *= num;
            }
            Console.WriteLine(factoriel);
        }
    }
}
