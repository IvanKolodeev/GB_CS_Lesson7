// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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

Console.WriteLine("enter number of rows: ");
int rows = int.Parse(Console.ReadLine()!);
Console.WriteLine("enter number of columns: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = new int[rows, columns];
Fill2DArray(array);

int sum = 0;
double avg;
for (int i = 0; i < columns; i++)
{
    for (int j = 0; j < rows; j++)
    {
        sum = sum + array[j, i];
    }
    avg = (double)sum / rows;
    Console.WriteLine($"average for column {i} = {Math.Round(avg,1)}");
    sum = 0;
}