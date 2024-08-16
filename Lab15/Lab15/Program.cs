using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Rectangle
    {
        private int a, b;

        public Rectangle(int sideA, int sideB)
        {
            a = sideA;
            b = sideB;
        }
        public void DisplaySides()
        {
            Console.WriteLine($"Сторона a: {a}, Сторона b: {b}");
        }
        public int CalculatePerimeter()
        {
            return 2 * (a + b);
        }
        public int CalculateArea()
        {
            return a * b;
        }
        public int SideA
        {
            get { return a; }
            set { a = value; }
        }
        public int SideB
        {
            get { return b; }
            set { b = value; }
        }
        public bool IsSquare
        {
            get { return a == b; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(7, 5);

            rect.DisplaySides();
            Console.WriteLine($"Периметр: {rect.CalculatePerimeter()}");
            Console.WriteLine($"Площадь: {rect.CalculateArea()}");

            Console.WriteLine($"Квадрат: {rect.IsSquare}");
        }
    }
}
