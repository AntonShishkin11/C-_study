using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_1B
{
    internal class Program
    {
        static List<string[]> ReadCsv(string filePath)
        {
            List<string[]> data = new List<string[]>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    data.Add(values);
                }
            }
            return data;
        }
        static void ZeroCaloriesItems(List<string[]> menuData)
        {
            Console.WriteLine("Блюда с нулевой калорийностью:");
            foreach (var item in menuData)
            {
                if (int.TryParse(item[3], out int calories) && calories == 0)
                {
                    Console.WriteLine(item[1]);
                }
            }
        }

        static void CalculateIron(List<string[]> menuData)
        {
            string targetItem = "McChicken";

            foreach (var item in menuData)
            {
                if (item[1].Contains(targetItem))
                {
                    string portionWeight = item[2];
                    int startIndex = portionWeight.IndexOf('(') + 1;
                    int endIndex = portionWeight.IndexOf(' ', startIndex);
                    double portionWeightGrams = double.Parse(portionWeight.Substring(startIndex, endIndex - startIndex), CultureInfo.InvariantCulture);
                    int ironInPortion = int.Parse(item[23], CultureInfo.InvariantCulture);
                    double neededPortion = 100.0 / ironInPortion;
                    Console.WriteLine($"Чтобы получить суточную норму железа, нужно купить {neededPortion:F2} порций {item[1]}" +
                                      $" или {neededPortion * portionWeightGrams:F2} грамм");
                }
            }

        }

        static void ItemsWithTransFat(List<string[]> menuData)
        {
            Console.WriteLine("Блюда с транс-жирами:");
            foreach (var item in menuData)
            {
                if (int.TryParse(item[9], out int transFat) && transFat > 0)
                {
                    Console.WriteLine($"{item[1]}, Транс-жиры: {transFat} г");
                }
            }
        }

        static void ItemsWithSugarAndCalories(List<string[]> menuData)
        {
            Console.WriteLine("Блюда с содержанием сахара от 1 до 10 грамм и калорийностью от 15 до 220:");
            foreach (var item in menuData)
            {
                if (int.TryParse(item[15], out int sugar) && int.TryParse(item[3], out int calories))
                {
                    if (sugar >= 1 && sugar <= 10 && calories >= 15 && calories <= 220)
                    {
                        Console.WriteLine($"{item[1]}, Калории: {calories}, Сахар: {sugar} г");
                    }
                }
            }
        }

        static void AverageTransFat(List<string[]> menuData)
        {
            string targetCategory = "Beef & Pork";
            int totalItems = 0;
            double totalTransFatRatio = 0.0;

            foreach (var item in menuData)
            {
                if (item[0] == targetCategory)
                {
                    if (int.TryParse(item[9], out int transFat) && int.TryParse(item[3], out int calories))
                    {
                        if (calories > 0)
                        {
                            double transFatRatio = (double)transFat / calories;
                            totalTransFatRatio += transFatRatio;
                            totalItems++;
                        }
                    }
                }
            }
            double averageTransFatRatio = totalTransFatRatio / totalItems;
            Console.WriteLine($"Средняя доля транс-жиров в категории \"{targetCategory}\": {averageTransFatRatio:P}");
        }
        static void Main(string[] args)
        {
            string filePath = "menu_McDonalds.csv";
            List<string[]> menuData = ReadCsv(filePath);

            Console.WriteLine("|----------------------------------Меню--------------------------------|");
            Console.WriteLine("| 1: Вывести список названий блюд с нулевой калорийностью              |");
            Console.WriteLine("| 2: Суточная норма железа в McChiken                                  |");
            Console.WriteLine("| 3: Блюда с содержанием сахара 1-10 грамм с калорийностью от 15 по 220|");
            Console.WriteLine("| 4: Блюда с транс-жирами                                              |");
            Console.WriteLine("| 5: Средняя доля транс-жиров в категории «Beef & Pork»                |");
            Console.WriteLine("| 6: Закрыть программу                                                 |");
            Console.WriteLine("|----------------------------------------------------------------------|");

            while (true)
            {
                Console.WriteLine("Введите число в соответсвии с выбором [0-5]: ");
                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int userChoice) && userChoice >= 1 && userChoice <= 6)
                {
                    if (userChoice == 1)
                    {
                        ZeroCaloriesItems(menuData);
                        Console.WriteLine();
                    }
                    else if (userChoice == 2)
                    {
                        CalculateIron(menuData);
                        Console.WriteLine();
                    }
                    else if (userChoice == 3)
                    {
                        ItemsWithSugarAndCalories(menuData);
                        Console.WriteLine();
                    }
                    else if (userChoice == 4)
                    {
                        ItemsWithTransFat(menuData);
                        Console.WriteLine();
                    }
                    else if (userChoice == 5)
                    {
                        AverageTransFat(menuData);
                        Console.WriteLine();
                    }
                    else if (userChoice == 6)
                    {
                        Console.WriteLine("Закрываем программу...");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Недопустимый ввод, попробуйте еще раз.");
                }
            }

        }
    }
}
