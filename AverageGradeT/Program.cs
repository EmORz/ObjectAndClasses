using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGradeT
{
    class Student
    {
        public Student()
        {
            Grade = new List<double>();
        }
        public Student(string name, List<double> grade)
        {
            Name = name;
            Grade = grade;
        }

        public string Name { get; set; }
        public List<double> Grade { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> excellentStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                var nameOfStudent = input[0];
                Student current = new Student();
                current.Name = nameOfStudent;
                for (int r = 1; r < input.Length; r++)
                {
                    current.Grade.Add(double.Parse(input[r]));
                }
                excellentStudents.Add(current);
            }
            excellentStudents = excellentStudents.Where(x => x.Grade.Average() >=5.0).OrderBy(x => x.Name).ThenByDescending(e => e.Grade.Average())
                .ToList();
            foreach (var student in  excellentStudents)
            {
                Console.Write(student.Name+" -> ");
                Console.WriteLine("{0:f2}",student.Grade.Average());
            }
            
        }
    }
}
