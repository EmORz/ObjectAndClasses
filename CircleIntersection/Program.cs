using System;
using System.Linq;

namespace CircleIntersection
{
    class Program
    {
        public class Circle
        {
            public Circle()
            {
            }

            public Circle(double x, double y, double radius)
            {
                X = x;
                Y = y;
                Radius = radius;
            }

            public double X { get; set; }
            public double Y { get; set; }
            public double Radius { get; set; }
        }
        static void Main(string[] args)
        {
            double[] coordinate1 = ReadCoordiante();
            double[] coordinate2 = ReadCoordiante();
            //
            Circle first = new Circle
            {
                X = coordinate1[0],
                Y = coordinate1[1],
                Radius = coordinate1[2]
            };
            //
            Circle second = new Circle
            {
                X = coordinate2[0],
                Y = coordinate2[1],
                Radius = coordinate2[2]
            };

            double radius = first.Radius + second.Radius;
            var dist = DistancePoint(first, second);
            var isIntersection = dist <= radius ? "Yes" : "No";
            Console.WriteLine(isIntersection);

        }

        private static double DistancePoint(Circle first, Circle second)
        {
            return  Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        private static double[] ReadCoordiante()
        {
            return Console.ReadLine().Split().Select(double.Parse).ToArray();
        }
    }
}
