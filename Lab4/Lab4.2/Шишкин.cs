using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._2
{
    internal class Шишкин
    {
        public static double F_x(double x)
        {
            /// Метод для нахождения значения функции f(x)
            double y = (Math.Pow(x, 3) / 3) * Math.Acos(x) - ((Math.Pow(x, 2) + 2) / 9) * Math.Sqrt(1 - Math.Pow(x, 2));
            return y;
        }

        public static double Pervoobr(double a, double b)
        {
            /// Метод Ньютона Лейбница
            double result = F_x(b) - F_x(a);
            return result;

        }

        public static double Pr_method(double a, double b)
        {
            /// Метод прямоугольников
            double n = 100;
            double step = (b - a) / n;
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                double x = a + i * step;
                sum += F_x(x);
            }
            return sum * step * -2;

        }

        public static double Tr_method(double a, double b)
        {
            ///Метод трапеции
            double n = 100;
            double step = (b - a) / n;
            double sum = 0.5 * (F_x(a) + F_x(b));

            for (int i = 1; i < n; i++)
            {
                double x = a + i * step;
                sum += F_x(x);
            }

            return sum * step * 2 * -1;
        }


        static void Main(string[] args)
        {
            Console.Write("Введите число a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите число b = ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine($"Приближенное значение интеграла (прямоугольники) = {Pr_method(a, b)}");
            Console.WriteLine($"Приближенное значение интеграла (трапеции) = {Pr_method(a, b)}");
            Console.WriteLine($"Аналитическое значение интеграла = {Pervoobr(a, b)}");
        }
    }
}
