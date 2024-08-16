using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._2
{
    internal class Program
    {
        static int[,] Matrix(int n)
        {
            Random rnd = new Random();
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(0, 5);
                }
            }

            return matrix;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool TEST(int[,] matrix, int k)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размерность (нечетное число): ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = Matrix(n);
            PrintMatrix(matrix);

            int k = 1;
            bool result = TEST(matrix, k);
            Console.WriteLine($"Все элементы k-го столбца нулевые: {result}");
        }
    }
}
