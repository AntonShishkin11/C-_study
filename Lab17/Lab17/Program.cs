using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    abstract class Publication
    {
        public abstract void DisplayInfo();
        public abstract bool IsMatch(string author);
    }

    class Book : Publication
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Книга: {Title}, {Author}, {Year}, {Publisher}");
        }

        public override bool IsMatch(string author)
        {
            return Author.EndsWith(author);
        }
    }

    class Article : Publication
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Journal { get; set; }
        public int IssueNumber { get; set; }
        public int Year { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Статья: {Title}, {Author}, {Journal}, {IssueNumber}, {Year}");
        }

        public override bool IsMatch(string author)
        {
            return Author.EndsWith(author);
        }
    }

    class ElectronicResource : Publication
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string URL { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Электронный ресурс: {Title}, {Author}, {URL}");
        }

        public override bool IsMatch(string author)
        {
            return Author.EndsWith(author);
        }
    }

    class Catalog
    {
        private List<Publication> publications = new List<Publication>();

        public void AddPublication(Publication publication)
        {
            publications.Add(publication);
        }

        public void DisplayAllPublications()
        {
            foreach (var publication in publications)
            {
                publication.DisplayInfo();
            }
        }

        public List<Publication> GetBooks()
        {
            return publications.FindAll(p => p.GetType() == typeof(Book));
        }

        public List<Publication> GetArticles()
        {
            return publications.FindAll(p => p.GetType() == typeof(Article));
        }

        public List<Publication> GetElectronicResources()
        {
            return publications.FindAll(p => p.GetType() == typeof(ElectronicResource));
        }

        public List<Publication> SearchByAuthor(string author)
        {
            List<Publication> results = new List<Publication>();

            foreach (var publication in publications)
            {
                if (publication.IsMatch(author))
                {
                    results.Add(publication);
                }
            }

            return results;
        }
    }


    class Program
    {
        static void DisplayPublications(List<Publication> publications)
        {
            foreach (var publication in publications)
            {
                publication.DisplayInfo();
            }
        }
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            string[] lines = File.ReadAllLines("izdanie.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length == 3)
                {
                    ElectronicResource resource = new ElectronicResource
                    {
                        Title = data[0],
                        Author = data[1],
                        URL = data[2]
                    };
                    catalog.AddPublication(resource);
                }
                else if (data.Length == 5)
                {
                    Article article = new Article
                    {
                        Title = data[0],
                        Author = data[1],
                        Journal = data[2],
                        IssueNumber = int.Parse(data[3]),
                        Year = int.Parse(data[4])
                    };
                    catalog.AddPublication(article);
                }
                else if (data.Length == 4)
                {
                    Book book = new Book
                    {
                        Title = data[0],
                        Author = data[1],
                        Year = int.Parse(data[2]),
                        Publisher = data[3]
                    };
                    catalog.AddPublication(book);
                }
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("|--------------Меню--------------|");
                Console.WriteLine("|1: Показать весь каталог        |");
                Console.WriteLine("|2: Показать Книги               |");
                Console.WriteLine("|3: Показать Статьи              |");
                Console.WriteLine("|4: Показать Электронные ресурсы |");
                Console.WriteLine("|5: Поиск по автору              |");
                Console.WriteLine("|6: Выход                        |");
                Console.WriteLine("|--------------------------------|");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nКаталог:");
                        catalog.DisplayAllPublications();
                        break;
                    case "2":
                        Console.WriteLine("\nКниги:");
                        DisplayPublications(catalog.GetBooks());
                        break;
                    case "3":
                        Console.WriteLine("\nСтатьи:");
                        DisplayPublications(catalog.GetArticles());
                        break;
                    case "4":
                        Console.WriteLine("\nЭлектронные ресурсы:");
                        DisplayPublications(catalog.GetElectronicResources());
                        break;
                    case "5":
                        Console.Write("\nВведите фамилию автора: ");
                        string author = Console.ReadLine();
                        Console.WriteLine($"Публикации от {author}:");
                        DisplayPublications(catalog.SearchByAuthor(author));
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ошибка. Пожалуйста, введите цифры от 1 до 6.");
                        break;
                }
            }
        }
    }

}
