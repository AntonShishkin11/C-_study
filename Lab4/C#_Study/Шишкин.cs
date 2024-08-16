using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Study
{
    internal class Шишкин
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число x = ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Введите число n = ");
            int n = int.Parse(Console.ReadLine());
            double S = 1;
            double u;

            for (int k = 3; k <= n; k++)
            {
                u = 0;
                for (int i = 1; i <= k+7; i++)
                {
                    if (i == 7) continue; // Пропускаем деление на 0
                    u += (Math.Pow(i, 3) - 27) / (i - 7);
                }
                if (k == 5 || u == 0) continue; // Пропускаем деление и умножение на 0
                S *= u * (Math.Pow(-2, k - 1) / (k - 5) * Math.Pow(x, k));
            }
            Console.WriteLine($"S = {S:F3}");
        }
    }
}
