using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace MentorClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Mentor> mentors = new Dictionary<string, Mentor>();
            string input1 = Console.ReadLine();
            while (input1 != "end of dates")
            {
                var name = input1.Split(' ', ',')[0];
                var data = input1.Split(' ', ',').Skip(1).ToList();
                // Console.WriteLine(name);
                if (!mentors.ContainsKey(name))
                {
                    mentors.Add(name, new Mentor());
                }
                for (int i = 0; i < data.Count(); i++)
                {
                    mentors[name].Dates.Add(DateTime.ParseExact(data[i], "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo));
                }
                
                input1 = Console.ReadLine();
            }
            //
            string input2 = Console.ReadLine();
            while (input2 != "end of comments")
            {
                var name = input2.Split('-')[0];
                var sentence = input2.Split('-')[1];
                if (mentors.ContainsKey(name))
                {
                    mentors[name].Comments.Add(sentence);
                }
                input2 = Console.ReadLine();
            }
            foreach (var mentor in mentors.OrderBy(x =>x.Key))
            {
                Console.WriteLine(mentor.Key);
                Console.WriteLine("Comments:");
                foreach (var comm in mentor.Value.Comments)
                {
                    Console.WriteLine($"- {comm}");
                }
                Console.WriteLine("Dates attended:");
                foreach (DateTime date in mentor.Value.Dates.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {(date).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
                }
            }

        }
    }
    class Mentor
    {
        public List<string> Comments;
        public List<DateTime> Dates;
        public Mentor()
        {
            Comments = new List<string>();
            Dates = new List<DateTime>();
        }
    }
}
