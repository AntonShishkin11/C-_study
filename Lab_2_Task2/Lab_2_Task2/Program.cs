using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Task2
{
    internal class Program
    {
        private static bool Multipl(int x)
        {
            int del_1 = x / 1000;
            int del_2 = x / 100 % 10;
            int del_3 = x / 10 % 10;
            int del_4 = x % 1000 % 10;

            return (del_1 * del_2 * del_3 * del_4) % 2 == 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите четырехзначное число ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Multipl(num));

        }
    }
}
