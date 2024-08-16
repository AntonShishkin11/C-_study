using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число x = ");
            int x = int.Parse(Console.ReadLine());
            double K = Math.Sqrt(Math.Pow((3 + x), 6) - Math.Log(x)) / Math.Pow(Math.E, 0) + Math.Asin(Math.Sin(Math.Pow(6*x, 2)));
            Console.WriteLine($"{K:F3}");
        }
    }
}
