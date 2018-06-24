using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BookLibrary
{
    class Program
    {
        public static IFormatProvider Culture { get; private set; }

        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            //
            SortedDictionary<string, DateTime> titleAndDate = new SortedDictionary<string, DateTime>();
            for (int i = 0; i < num; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                //
                var title = inputData[0];
               // var price = double.Parse(inputData[5]);
                var dateRealesed = DateTime.ParseExact(inputData[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                //
                if (!titleAndDate.ContainsKey(title))
                {
                    titleAndDate.Add(title, new DateTime());
                }
                titleAndDate[title] = dateRealesed;
               // Console.WriteLine(dateRealesed);
                
            }
            var borderDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var item in titleAndDate.OrderBy(date => date.Value))
            {
                if (item.Value>borderDate)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.ToString("dd.MM.yyyy")}");
                }

            }
        }
    }
}
