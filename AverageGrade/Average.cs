using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGrade
{
    class Student
    {
        public string studentName;
        public List<double> studentGrade = new List<double>();
        public double Average;
    }
    class Average
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            List<Student> excellent = new List<Student>();

            for (int i = 0; i < num; i++)
            {
                var studentInfo = Console.ReadLine().Split();

                Student newStudent = new Student();
                newStudent.studentName = studentInfo[0];

                for (int j = 1; j < studentInfo.Length; j++)
                {
                    newStudent.studentGrade.Add(double.Parse(studentInfo[j]));
                }
                newStudent.Average = newStudent.studentGrade.Average();

                if (newStudent.Average>=5.00)
                {
                    excellent.Add(newStudent);
                }
            }
            excellent = excellent.OrderBy(x => x.studentName).ThenByDescending(x => x.Average).ToList();
            foreach (var st in excellent)
            {
                Console.Write(st.studentName);
                Console.WriteLine($" -> {st.Average:f2}");
            }
            
        }
    }
}
