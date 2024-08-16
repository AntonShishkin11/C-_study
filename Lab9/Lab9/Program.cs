using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> class1 = new List<double>();
            List<double> class2 = new List<double>();
            List<double> class3 = new List<double>();

            foreach (var line in File.ReadLines("data2024.csv"))
            {
                string[] array_line = line.Split(',');
                double value;
                if (double.TryParse(array_line[6], out value))
                {
                    if (value != 0)
                    {
                        if (array_line[2] == "1") { class1.Add(value); }
                        else if (array_line[2] == "2") { class2.Add(value); }
                        else { class3.Add(value); }
                    }
                }
            }
            Console.WriteLine($"Средний возраст пассажиров первого класса: {Math.Round(class1.Average())}");
            Console.WriteLine($"Средний возраст пассажиров второго класса: {Math.Round(class2.Average())}");
            Console.WriteLine($"Средний возраст пассажиров третьего класса: {Math.Round(class3.Average())}");

        }
    }
}
