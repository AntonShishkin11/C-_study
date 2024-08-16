using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main()
        {
            int n = 5;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();

                for (int f = 0; f < i; f++)
                {
                    Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }
        
    }
}
