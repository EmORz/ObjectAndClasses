using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales
{
    class Sales
    {
        static void Main(string[] args)
        {
            var numIteration = int.Parse(Console.ReadLine());

            Dictionary<string, double> dataBaseForSale = new Dictionary<string, double>();

            for (int i = 0; i < numIteration; i++)
            {
                var dataForSale = Console.ReadLine().Split();
                var city = dataForSale[0];
                var midleSum = double.Parse(dataForSale[2]) * double.Parse(dataForSale[3]);

                if (!dataBaseForSale.ContainsKey(city))
                {
                    dataBaseForSale.Add(city, 0);
                }
                dataBaseForSale[city] += midleSum;
            }
            foreach (var saleInCity in dataBaseForSale.OrderBy(town => town.Key))
            {
                Console.Write(saleInCity.Key+" -> ");
                Console.WriteLine($"{saleInCity.Value:f2}");
            }
        }
    }
}
