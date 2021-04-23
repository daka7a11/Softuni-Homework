using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionsOfMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string snake = Console.ReadLine();
            int rows = dimensionsOfMatrix[0];
            int columns = dimensionsOfMatrix[1];
            char[,] matrix = new char[rows, columns];
            int currLetter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[currLetter];
                        currLetter++;
                        if (currLetter == snake.Length)
                        {
                            currLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[currLetter];
                        currLetter++;
                        if (currLetter == snake.Length)
                        {
                            currLetter = 0;
                        }
                    }
                }
            }
            PrintMatrix(matrix);

        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
