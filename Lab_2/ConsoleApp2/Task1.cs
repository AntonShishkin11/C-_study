using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Task1
    {
        private static int Proggr(int x, int y, int z)
        {
            int yz = y * z;
            
            int dels_1 = (x - 1) / y;
            int arifm_1 = ((y + y * dels_1) * dels_1) / 2;
            int dels_2 = (x - 1) / z;
            int arifm_2 = ((z + z * dels_2) * dels_2) / 2;
            int dels_3 = (x - 1) / yz;
            int arifm_3 = ((yz + yz * dels_3) * dels_3) / 2;
            return arifm_1 + arifm_2 - arifm_3; 
        }

        static void Main(string[] args)
        {
            Console.Write("Введите любое число ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Введите первый делитель ");
            int del_1 = int.Parse(Console.ReadLine());
            Console.Write("Введите второй делитель ");
            int del_2 = int.Parse(Console.ReadLine());

            Console.WriteLine(Proggr(num, del_1, del_2));

        }
    }
}
