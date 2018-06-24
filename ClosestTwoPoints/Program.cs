using System;
using System.Linq;

namespace ClosestTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = Readers();
            Point[] closestTwoPoints = FindClosestPoint(points);
            Console.WriteLine($"{CalcDistance(closestTwoPoints[0], closestTwoPoints[1]):f3}");
            Console.WriteLine($"({closestTwoPoints[0].X}, {closestTwoPoints[0].Y})");
            Console.WriteLine($"({closestTwoPoints[1].X}, {closestTwoPoints[1].Y})");

        }


        public static Point[] FindClosestPoint(Point[] pointsArray)
        {
            var min = double.MaxValue;
            Point[] find = null;

            for (int i = 0; i < pointsArray.Length; i++)
            {
                for (int i1 = i+1; i1 < pointsArray.Length; i1++)
                {
                    double dist = CalcDistance(pointsArray[i], pointsArray[i1]);

                    if (dist<min)
                    {
                        min = dist;
                        Point X;
                        Point Y;
                        find = new Point[] { X = pointsArray[i], Y = pointsArray[i1] };

                    }

                }
            }
            return find;
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
        }
        static Point[] Readers()
        {
            int n = int.Parse(Console.ReadLine());

            Point[] pointsArray = new Point[n];

            for (int i = 0; i < n; i++)
            {
                pointsArray[i] = Reader();
            }
            return pointsArray;
        }
        static Point Reader()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point points = new Point { X = array[0], Y = array[1]};
            return points;
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
