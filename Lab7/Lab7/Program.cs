using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Program
    {
        private static void Words_with_letter(string text)
        {
            string[] text_list = text.Split(' ');
            char[] symb = { ':', ';', ',', '.', '-', '?', '!', '(', ')', '"' };
            Console.WriteLine("Слова оканчивающиеся на букву 'я': ");
            foreach (var word in text_list)
            {
                if (word.Trim(symb).EndsWith("я"))
                    Console.WriteLine(word.Trim(symb));
            }
        }

        static void Main(string[] args) 
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            Words_with_letter(text);
        }
    }
}
