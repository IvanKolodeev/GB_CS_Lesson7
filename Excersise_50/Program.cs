// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

void PrintArray(int[,] matrix)
{
    Console.WriteLine("Your matrix is");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void Fill2DArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        bool isValidRow = false;
        while (!isValidRow)
        {
            Console.WriteLine($"Enter {matrix.GetLength(1)} values for row {i+1} separated by spaces");
            string input = Console.ReadLine()!;
            string[] values = input.Split(' ')!;      
            
            if (matrix.GetLength(1) == values.Length) isValidRow = true;
            
            else
            {
                Console.WriteLine("Insufficient number of values entered, please reenter");
                continue;
            }
            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                if (!int.TryParse(values[j], out int value))
                {
                    isValidRow = false;
                    Console.WriteLine($"Invalid input value: {values[j]}, please reenter line");
                    break;
                }
                else 
                {
                    matrix[i, j] = value;
                    isValidRow = true;
                }
            }
        }

    }
    PrintArray(matrix);
}

void FindNumberIndex (int a, int[,] matrix)
{
    int count = 1;
    Boolean found = false;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (a == matrix[i,j])
            {
                Console.WriteLine ($"{count}st coincidence is element [{i} {j}]");
                count++;
                found = true;
            }
        }
    }
    
    if (found != true) Console.WriteLine("No coincidence found");
}

Console.WriteLine("enter number of rows: ");
int rows = int.Parse(Console.ReadLine()!);
Console.WriteLine("enter number of columns: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = new int[rows, columns];
Fill2DArray(array);

Console.WriteLine("Enter a number to be located ");
int num = int.Parse(Console.ReadLine()!);
FindNumberIndex(num, array);