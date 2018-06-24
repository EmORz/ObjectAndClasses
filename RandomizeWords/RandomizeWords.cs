using System;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            //Welcome to SoftUni and have fun learning programming

            var data = Console.ReadLine().Split();
            Random words = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                int num = words.Next(0, data.Length);
                int nums = words.Next(0, data.Length);
                string change = data[num];
                data[num] = data[nums];
                data[nums] = change;
            }
            Console.WriteLine(string.Join(Environment.NewLine,data));
            
        }
    }
}
