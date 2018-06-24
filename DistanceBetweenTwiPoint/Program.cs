using System;
using System.Linq;
using System.Collections.Generic;

namespace DistanceBetweenTwiPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = Reader(Console.ReadLine());
            Point point2 = Reader(Console.ReadLine());
            var distance = CalcDistance(point1, point2);
            //
            Console.WriteLine($"{distance:f3}");
        }
       
        static Point Reader(string input)
        {
            var coordinates = input.Split().Select(int.Parse).ToArray();
            return new Point
            {
                X = coordinates[0],
                Y = coordinates[1]
            };
        }

        static double CalcDistance(Point point1, Point point2)
        {
            var midX = point1.X - point2.X;
            var midY = point1.Y - point2.Y;
            midX *= midX;
            midY *= midY;
            midY += midX;
            var distance = Math.Sqrt(midY);
            return distance;

            return 0.0;
        }

        
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
