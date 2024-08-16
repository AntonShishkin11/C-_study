using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
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

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    default:
                        throw new IndexOutOfRangeException("Ошибка. Напишите 0 для стороны a или 1 для стороны b.");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        a = value;
                        break;
                    case 1:
                        b = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Ошибка. Напишите 0 для стороны a или 1 для стороны b.");
                }
            }
        }

        public static Rectangle operator ++(Rectangle rect)
        {
            return new Rectangle(rect.a + 1, rect.b + 1);
        }

        public static Rectangle operator --(Rectangle rect)
        {
            return new Rectangle(rect.a - 1, rect.b - 1);
        }

        public static bool operator true(Rectangle rect)
        {
            return rect.a == rect.b;
        }

        public static bool operator false(Rectangle rect)
        {
            return rect.a != rect.b;
        }

        public static Rectangle operator *(Rectangle rect, int scalar)
        {
            return new Rectangle(rect.a * scalar, rect.b * scalar);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 5);

            Console.WriteLine($"Сторона a: {rect[0]}, Сторона b: {rect[1]}");

            ++rect;
            rect.DisplaySides();

            --rect;
            rect.DisplaySides();

            if (rect)
            {
                Console.WriteLine("Прямоугольник является квадратом.");
            }
            else
            {
                Console.WriteLine("Прямоугольник не является квадратом.");
            }

            Rectangle scaledRect = rect * 3;
            scaledRect.DisplaySides();
        }
    }
}
