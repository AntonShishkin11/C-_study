//Console.Write("Введите число N = ");
//int n = int.Parse(Console.ReadLine());
//Console.Write("Введите число X = ");
//int x = int.Parse(Console.ReadLine());
//Console.Write("Введите число Y = ");
//int y = int.Parse(Console.ReadLine());

//int countX = (n - 1) / x;
//int countY = (n - 1) / y;
//int countXY = (n - 1) / (x*y);
//int res = countX + countY - countXY;
//Console.WriteLine(res);

Console.Write("Введите число x = ");
int x = int.Parse(Console.ReadLine());
Console.Write("Введите число с = ");
int c = int.Parse(Console.ReadLine());
double L = Math.Tan(c) + (2 * Math.Pow(x, 2) + 5) / Math.Sqrt(c + 1);
Console.WriteLine($"{L:F3}");
Console.WriteLine(L);
Console.WriteLine(Math.Round(L, 3));