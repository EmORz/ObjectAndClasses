using System;
using System.Collections.Generic;
using System.Linq;

namespace AndreyBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            var amount = int.Parse(Console.ReadLine());

            Dictionary<string, double> priceList = new Dictionary<string, double>();
            for (int i = 0; i < amount; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '-'});
                var typeProduct = input[0];
                var price = Math.Round(double.Parse(input[1]), 2);
                if (!priceList.ContainsKey(typeProduct))
                {
                    priceList.Add(typeProduct, 0.0);
                }
                priceList[typeProduct] = price;
            }
            var clientInput = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> clientData = new Dictionary<string, Dictionary<string, double>>();
            while (clientInput != "end of clients")
            {
                string[] clients = clientInput.Split(new char[] {'-', ',' });
                var nameOfClient = clients[0];
                var clientsProduct = clients[1];
                var quantity = Math.Round(double.Parse(clients[2]), 2);
                if (priceList.ContainsKey(clientsProduct))
                {
                    if (!clientData.ContainsKey(nameOfClient))
                    {
                        clientData.Add(nameOfClient, new Dictionary<string, double>() );
                    }
                    if (!clientData[nameOfClient].ContainsKey(clientsProduct))
                    {
                        clientData[nameOfClient].Add(clientsProduct, 0.0);
                    }
                    clientData[nameOfClient][clientsProduct] += quantity;
                }
                clientInput = Console.ReadLine();
            }
            decimal totalBill = 0m;
            foreach (var item in clientData.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                var bill = 0.0;
                foreach (var i in item.Value)
                {
                    Console.WriteLine($"-- {i.Key} - {i.Value}");
                    foreach (var qu in priceList)
                    {
                        if (qu.Key == i.Key)
                        {
                            bill += qu.Value * i.Value;
                        }
                    }

                }
                Console.WriteLine($"Bill: {bill:f2}");
                totalBill += (decimal)bill;

            }
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
        
    }
}
