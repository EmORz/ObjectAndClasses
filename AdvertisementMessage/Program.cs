using System;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var numMessage = int.Parse(Console.ReadLine());
            //{phrase} {event} {author} – {city}.
            string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            //
            Random obj = new Random();
            //Index

            for (int i = 0; i < numMessage; i++)
            {
                var phrasesIndex = obj.Next(0, phrases.Length);
                var eventsIndex = obj.Next(0, events.Length);
                var authorsIndex = obj.Next(0, authors.Length);
                var citiesIndex = obj.Next(0, cities.Length);

                Console.WriteLine($"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} – {cities[citiesIndex]}.");
            }
        }
    }
}
