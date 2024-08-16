using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Шишкин
{
    internal class Шишкин
    {
        public static double F_x(double x)
        {
            /// Метод для нахождения значения функции f(x)
            double y = Math.Pow(x, 2) - x * Math.PI * Math.Cos(Math.PI * x);
            return y;
        }
        public static double F_der(double x)
        {
            /// Метод для нахождения производной функции
            double y = 2 * x - Math.PI * (Math.Cos(Math.PI * x) - Math.PI * x * Math.Sin(Math.PI * x));
            return y;
        }
        public static void Create_table(double a, double b)
        {
            /// Метод формирующий таблицу
            Console.WriteLine($"{"i",5} | {"xi",10} | {"yi",10}");
            Console.WriteLine($"-------------------------------");

            for (int i = 0; i < 21; i++)
            {
                double x = a + (i * ((b - a) / 20F));
                Console.WriteLine($"{i,5} | {x,10:F3} | {F_x(x),10:F3}");
            }
            Console.WriteLine($"-------------------------------");
        }
        public static void N_method(double a, double b)
        {
            /// Метод Ньютона
            int c = 0;
            double x = (b - a) / 2;
            double x1 = x - F_x(x) / F_der(x);
            while (Math.Abs(F_x(x)) > Math.Pow(10, -5))
            {
                x = x1;
                x1 = x - F_x(x) / F_der(x);
                c = c + 1;
            }
            Console.WriteLine($"Корень уравнения по Ньютону = {x1,3:F5}\nПолучен за {c} итераций");
        }
        public static void D_method(double a, double b)
        {
            /// Метод дехотомии
            int co = 0;
            double x1, x2, x3, f1, f2;

            do
            {
                x3 = (a + b) / 2;
                x1 = (a + x3) / 2;
                x2 = (x3 + b) / 2;

                f1 = F_x(x1);
                f2 = F_x(x2);

                if (f1 < f2)
                {
                    b = x2;
                    co = co + 1;
                }
                else
                {
                    a = x1;
                    co = co + 1;
                }
            } while (Math.Abs(b - a) > Math.Pow(10, -5));

            Console.WriteLine($"Корень уравнения по дихотомии = {(a + b) / 2,3:F5}\nПолучен за {co} итераций");
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите число b = ");
            double b = double.Parse(Console.ReadLine());

            Create_table(a, b);
            N_method(a, b);
            D_method(a, b);


            

        }
    }
}
