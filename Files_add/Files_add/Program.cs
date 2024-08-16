using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Files_add
{
    internal class Program
    {   
        public static void Create_table()
        {
            /// Метод формирующий таблицу 
            Console.WriteLine($"{"Фамилия",10} | {"Имя",10} | {"Отчество",14} | {"Номер телефона",14} | {"Домашний адрес", 90} " +
                $"| {"Марка Автомобиля",17} | {"Номер Автомобиля",17} | {"Номер Техпаспорта",10}");

            Console.WriteLine($"--------------------------------------------------------------------------------------------------" +
                $"----------------------------------------------------------------------------------------------------------------");

            foreach (var line in File.ReadLines("Владелец автомобиля.csv"))
            {
                string[] array_line = line.Split(';');
                Console.WriteLine($"{array_line[0],10} | {array_line[1],10} | {array_line[2],14} | {array_line[3], 14} " +
                $"| {array_line[4],90} | {array_line[5],17} | {array_line[6],17} | {array_line[7],10}");
            }
            Console.WriteLine($"--------------------------------------------------------------------------------------------------" +
                $"----------------------------------------------------------------------------------------------------------------");
        }
        private static void Add_new_line()
        {
            /// Метод добавляет в файл новую запись
            Console.WriteLine("Введите данные в формате: Фамилия; Имя; Отчество; Номер телефона; Домашний адрес " +
                "(почтовый индекс, страна, область, район, город, улица, дом, квартира); Марка автомобиля; Номер автомобиля; Номер техпаспорта");
            var new_line = Console.ReadLine();
            string newEntry = new_line + Environment.NewLine;
            File.AppendAllText("Владелец автомобиля.csv", newEntry);
        }

        private static void Filter_by_mark(string mark)
        {
            bool found = false;
            var lines = File.ReadLines("Владелец автомобиля.csv");
            foreach (var line in lines)
            {
                string[] array_line = line.Split(';');
                if (array_line.Length >= 6 && string.Equals(array_line[5].Replace(" ", ""), mark.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }
            if (!found) { Console.WriteLine("В файле нет информации о водителях данной марки"); return; }

            Console.WriteLine($"Информация о владельцах автомобилей марки {mark}");
            Console.WriteLine($"{"Фамилия",-10} | {"Имя",-10} | {"Отчество",-14} | {"Номер телефона",-14} | {"Домашний адрес",-90} " +
                $"| {"Марка Автомобиля",-17} | {"Номер Автомобиля",-17} | {"Номер Техпаспорта",-10}");

            Console.WriteLine($"--------------------------------------------------------------------------------------------------" +
                $"----------------------------------------------------------------------------------------------------------------");
            foreach (var line in lines)
            {
                string[] array_line = line.Split(';');
                if (string.Equals(array_line[5].Replace(" ", ""), mark.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{array_line[0],-10} | {array_line[1],-10} | {array_line[2],-14} | {array_line[3],-14} " +
                                      $"| {array_line[4],-90} | {array_line[5],-17} | {array_line[6],-17} | {array_line[7],-10}");
                }
            }
            Console.WriteLine($"--------------------------------------------------------------------------------------------------" +
                $"----------------------------------------------------------------------------------------------------------------");
        }
        private static void New_file_data(string mark)
        {
            Console.WriteLine("Введите название для нового файла:");
            var newFileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter($"{newFileName}.csv"))
            {
                writer.WriteLine($"{"Фамилия",10}; {"Имя",10}; {"Отчество",14}; {"Номер телефона",14}; {"Домашний адрес",90}; " +
                    $"{"Марка Автомобиля",17}; {"Номер Автомобиля",17}; {"Номер Техпаспорта",10}");

                var lines = File.ReadLines("Владелец автомобиля.csv");
                foreach (var line in lines)
                {
                    string[] array_line = line.Split(';');
                    if (string.Equals(array_line[5].Replace(" ", ""), mark.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                    {
                        writer.WriteLine($"{array_line[0],10}; {array_line[1],10}; {array_line[2],14}; {array_line[3],14}; " +
                            $"{array_line[4],90}; {array_line[5],17}; {array_line[6],17}; {array_line[7],10}");
                    }
                }

                Console.WriteLine($"Отфильтрованные данные записаны в файл {newFileName}.csv");
            }
        }
            static void Main(string[] args)
        {
            Console.WriteLine("|-----------------------Меню-----------------------|");
            Console.WriteLine("| 1: Отобразить содержимое файла                   |");
            Console.WriteLine("| 2: Добавить запись в файл                        |");
            Console.WriteLine("| 3: Информация о водителях определенной марки     |");
            Console.WriteLine("| 4: Записать отфильтрованные данные в новый файл  |");
            Console.WriteLine("| 5: Закрыть программу                             |");
            Console.WriteLine("|--------------------------------------------------|");

            while (true)
            {
                Console.WriteLine("Введите число в соответсвии с выбором [1-5]: ");
                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int userChoice) && userChoice >= 1 && userChoice <= 5)
                {
                    if (userChoice == 1)
                    {
                        Create_table();
                    }
                    else if (userChoice == 2)
                    {
                        Add_new_line();
                    }
                    else if (userChoice == 3)
                    {
                        Console.WriteLine("Введите марку автомобиля: ");
                        var mark = Console.ReadLine();
                        Filter_by_mark(mark);

                    }
                    else if (userChoice == 4)
                    {
                        Console.WriteLine("Введите марку автомобиля: ");
                        var mark = Console.ReadLine();
                        New_file_data(mark);
                    }
                    else if (userChoice == 5)
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
