using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MentorGroup
{
    class Program
    {
        private static IFormatProvider cultureinfo;

        static void Main(string[] args)
        {
            // end of dates
            /*nakov 22/08/2016,20/08/2016
              simeon10 22/08/2016.28/04/1986
            */
            //Read user name and date
            var userNameAndDate = Console.ReadLine();
            SortedDictionary<string, List<DateTime>> dataForNameAndDate = new SortedDictionary<string, List<DateTime>>();
            
            while (userNameAndDate != "end of dates")
            {
                var userName = userNameAndDate.Split(' ')[0];
                var date = userNameAndDate.Split(new char[] {' ', ',' }).Select(DateTime.Parse).Skip(1).ToList();
                
                if (!dataForNameAndDate.ContainsKey(userName))
                {
                    dataForNameAndDate.Add(userName, new List<DateTime>());
                }
                dataForNameAndDate[userName] = date;
                userNameAndDate = Console.ReadLine();
            }

            Dictionary<string, List<string>> dataForUsersComments = new Dictionary<string, List<string>>();

            //Read comments
            var userComments = Console.ReadLine();
            //end of comments 
            while (userComments != "end of comments")
            {
                var user = userComments.Split(new char[] { '-' })[0];
                var comment = userComments.Split(new char[] { '-' }).Skip(1).ToList();
                if (!dataForUsersComments.ContainsKey(user))
                {
                    dataForUsersComments.Add(user, new List<string>());
                }
                dataForUsersComments[user] = comment;
                userComments = Console.ReadLine();
            }
            List<DateTime> order = new List<DateTime>();

            foreach (var user in dataForNameAndDate)
            {
                Console.WriteLine(user.Key);
                Console.WriteLine("Comments:");
                foreach (var comment in dataForUsersComments)
                {
                    foreach (var person in comment.Value)
                    {
                        if (user.Key == comment.Key)
                        {
                            Console.WriteLine($"- " + person);
                        }
                    }
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in user.Value)
                {
                    order.Add(date);
                }
                foreach (var or in order.OrderBy(x => x))
                {
                    string str = or.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Console.WriteLine("-- "+str);
                }
                order.Clear();
            }
        }
    }
}
