using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }

        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var numIteration = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            CreatorTeams(numIteration, teams);
            JoinToTeams(teams);
            //Print and order by
            teams = teams.OrderByDescending(y => y.Members.Count).ThenBy(name => name.TeamName).ToList();
            foreach (Team item in teams)
            {
                if (item.Members.Count!=0)
                {
                    Console.WriteLine(item.TeamName);
                    Console.WriteLine("- "+item.Creator);
                    foreach (var i in item.Members.OrderBy(x => x))
                    {
                        Console.WriteLine("-- " + i);
                    }
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team disban in teams.OrderBy(d => d.TeamName))
            {
                if (disban.Members.Count == 0)
                {
                    Console.WriteLine(disban.TeamName);
                }
            }

        }

        private static void JoinToTeams(List<Team> teams)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of assignment")
                {
                    break;
                }
                string[] partOfData = input.Split(new char[] {'-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string nameJoin = partOfData[0];
                string teamJoin = partOfData[1];

                if (teams.All(x => x.TeamName != teamJoin))
                {
                    Console.WriteLine($"Team {teamJoin} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.Members.Contains(nameJoin) || teams.Any(c => c.Creator == nameJoin)))
                {

                    Console.WriteLine($"Member {nameJoin} cannot join team {teamJoin}!");
                    continue;
                }
                int index = teams.FindIndex(x => x.TeamName == teamJoin);
                teams[index].Members.Add(nameJoin);
            }
        }

        private static void CreatorTeams(int n, List<Team> teams)  
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string team = input[1];

                if (teams.Any(x => x.TeamName == team ))
                {
                    Console.WriteLine($"Team {team} was already created!");
                    continue;
                }
                if (teams.Any(x => x.Creator == name))
                {
                    Console.WriteLine($"{name} cannot create another team!");
                    continue;
                }
                else
                {
                    Team current = new Team();
                    current.TeamName = team;
                    current.Creator = name;
                    teams.Add(current);
                    Console.WriteLine($"Team {team} has been created by {name}!");
                }

            }
        }

    }
}
