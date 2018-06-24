using System;
using System.Globalization;

namespace DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            var dateInStr = Console.ReadLine();
            DateTime dateTime = DateTime.ParseExact(dateInStr, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(dateTime.DayOfWeek);
        }
    }
}
