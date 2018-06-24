using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleByClass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var sales = new Dictionary<string, List<Sale>>();

            for (int i = 0; i < n; i++)
            {
                var sale = ReadSale();

                if (!sales.ContainsKey(sale.Town))
                {
                    sales.Add(sale.Town, new List<Sale>());
                }
                sales[sale.Town].Add(sale);

            }
            foreach (var townSale in sales.OrderBy(x => x.Key))
            {
                var town = townSale.Key;
                var sumOfSale = townSale.Value.Sum(x => x.Price* x.Quantity);
                Console.WriteLine(town+$" -> {sumOfSale:f2}");
            }
        }
        static Sale ReadSale()
        {
            var saleRead = Console.ReadLine().Split();

            return new Sale
            {
                Town = saleRead[0],
                Product = saleRead[1],
                Price = double.Parse(saleRead[2]),
                Quantity = double.Parse(saleRead[3])

            };
        }
        class Sale
        {
            // Town, Product, Price and Quantity
            public string Town { get; set; }
            public string Product { get; set; }
            public double Price { get; set; }
            public double Quantity { get; set; }
        }
    }

}
