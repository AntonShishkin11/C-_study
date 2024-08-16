using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Program
    {
        private static int [] CreateArray(int n)
        {
            Random rnd = new Random();
            var x = new int[n];

            for (int i = 0; i < n; i++) {x[i] = rnd.Next(100);}
            return x;
        }
        private static void Print(int[] x) 
        {
            foreach (var item in x) Console.Write($"{item,3}");
            Console.WriteLine();
        }
        private static void SumInEl(int[] x)
        {
            int minEl = x[0];
            int minIn = 0;
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] < minEl)
                {
                    minEl = x[i];
                    minIn = i;
                }
            }
            int sum = minEl + minIn;
            Console.WriteLine($"Индекс минимального элемента = {minIn}");
            Console.WriteLine($"Минимальный элемент массива = {minEl}");
            Console.WriteLine($"Сумма индекса и минимального элемента массива = {sum}");
        }
        static void Main(string[] args)
        {
            int[] x = CreateArray(15);
            Print(x);
            SumInEl(x);
        }
    }
}
