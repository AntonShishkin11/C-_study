using System;
using String_searcher;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace Lab10
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            Console.WriteLine(Words_ending_with.Words_end_letter(text));
        }
    }
}
