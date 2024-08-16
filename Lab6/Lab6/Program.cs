using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Program
    {
        static void Print(int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                    if (i == 0 || i == x.GetLength(0) - 1 || j == 0 || j == x.GetLength(0) - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(x[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(x[i, j] + " ");
                    }
                Console.WriteLine();
            }
        }
        private static int[,] Matrix(int n)
        {
            Random rnd = new Random();
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(10, 100);
            return a;
        }
        private static int MaxEl(int n, int[,] a)
        {
            int maxEl = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                    {
                        if (a[i, j] > maxEl)
                        {
                            maxEl = a[i, j];
                        }
                    }
                }
            }
            return maxEl;
        }
            static void Main(string[] args)
        {
            Console.Write("Введите размерность (нечетное число): ");
            int n = int.Parse(Console.ReadLine());

            int[,] a = Matrix(n);
            Print(a);
            Console.WriteLine($"Максимальный элемент выделенной области: {MaxEl(n, a)}");
        }
    }
}
