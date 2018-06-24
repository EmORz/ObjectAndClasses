using System;
using System.Globalization;

namespace CountWorkingDay
{
    class CountDays
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var count = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                if ((date.Day == 24||date.Day==25||date.Day == 26)&&date.Month ==12)
                {
                    continue;
                }
                if ((date.Day == 1 && date.Month == 1)||(date.Day == 3 && date.Month == 3)
                    ||((date.Day == 1 || date.Day ==6 || date.Day == 24) && date.Month == 5)
                    ||((date.Day == 6 || date.Day == 22) && date.Month == 9)
                    ||(date.Day == 1 && date.Month == 11))
                {
                    continue;
                }
                else
                {
                    count++;
                }
            }
            Console.WriteLine(count);


        }
    }
}
