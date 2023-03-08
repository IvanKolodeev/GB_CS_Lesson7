// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// columns = 3, rows = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

double[,] CreateArrayRandom(int rows, int columns, double min, double max)
{
    double [,] result = new double[rows, columns];
    Random rand = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = Math.Round(rand.NextDouble() * (max-min) + min , 1);
        }
    }

    return result;
}

void PrintArray(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j].ToString("F1")} ");
        }
        Console.WriteLine();
    }
}


Console.WriteLine("enter number of columns: ");
int rows = int.Parse(Console.ReadLine()!);

Console.WriteLine("enter number of strings: ");
int columns = int.Parse(Console.ReadLine()!);

Console.WriteLine("enter minimum value: ");
double min = double.Parse(Console.ReadLine()!);

Console.WriteLine("enter maximum value: ");
double max = double.Parse(Console.ReadLine()!);

double[,] matrix = CreateArrayRandom(columns, rows, min, max);

PrintArray(matrix);