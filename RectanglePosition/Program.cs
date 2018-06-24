using System;
using System.Linq;

namespace RectanglePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = Read(Console.ReadLine());
            Rectangle rect2 = Read(Console.ReadLine());

            var check = IsInside(rect1, rect2);
            var result = check ? "Inside" : "Not inside";
            Console.WriteLine(result);


        }
        static bool IsInside(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Left >= rect2.Left
                && rect1.Right<= rect2.Right
                && rect1.Top<=rect2.Top
                &&rect1.Bottom<=rect2.Bottom)
            {
                return true;
            }
            return false;
        }
        static Rectangle Read(string input)
        {
            var properties = input.Split().Select(int.Parse).ToArray();

            return new Rectangle { Top = properties[1], Left = properties[0], Width = properties[2], Height = properties[3],
                Right = properties[0]+properties[2],
               Bottom = properties[1]+properties[3]};
        }
    }
    class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
}
