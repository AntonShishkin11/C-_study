using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Anton\\OneDrive\\Рабочий стол\\Prog_practice\\VS_c#\\FileParser\\FileParser\\clients.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
    }
}
