using System;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int inputRows = int.Parse(input[0]);
            int inputColumns = int.Parse(input[1]);
            string[,] matrix = new string[inputRows, inputColumns];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                input = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            input = Console.ReadLine().Split();
            while (input[0].ToLower() != "end")
            {
                if (input[0].ToLower() == "swap" && input.Length == 5)
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);
                    if (row1 < 0 || row1 >= matrix.GetLength(0)
                     || row2 < 0 || row2 >= matrix.GetLength(0)
                     || col1 < 0 || col1 >= matrix.GetLength(1)
                     || col2 < 0 || col2 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                        input = Console.ReadLine().Split();
                        continue;
                    }
                    if (input[0].ToLower() == "swap")
                    {
                        string swapVar = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = swapVar;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine().Split();
                    continue;
                }
                PrintMatrix(matrix);
                input = Console.ReadLine().Split();
            }
        }
        static public void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
