using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] nums = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < input.Length; i += 2)
            {
                int bombRow = input[i];
                int bombCol = input[i + 1];
                int bombPower = matrix[bombRow, bombCol];
                if (bombPower<=0)
                {
                    continue;
                }
                if (IsCoordinatesValid(matrix, bombRow - 1, bombCol)) // UP
                {
                    if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow - 1, bombCol + 1)) // UP-RIGHT 
                {
                    if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow, bombCol + 1)) // RIGHT
                {
                    if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow + 1, bombCol + 1)) // RIGHT-DOWN
                {
                    if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow + 1, bombCol)) // DOWN
                {
                    if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow + 1, bombCol - 1)) // DOWN-LEFT
                {
                    if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow, bombCol - 1)) // LEFT
                {
                    if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombPower;
                    }
                }
                if (IsCoordinatesValid(matrix, bombRow - 1, bombCol - 1)) // LEFT-UP
                {
                    if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombPower;
                    }
                }
                matrix[bombRow, bombCol] = 0;
            }
            Console.WriteLine($"Alive cells: {AliveCells(matrix)}");
            Console.WriteLine($"Sum: {SumPositiveNums(matrix)}");
            PrintMatrix(matrix);
        }
        static bool IsCoordinatesValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        static void PrintMatrix(int[,] matrix)
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
        static int SumPositiveNums(int[,]matrix)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]>0)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            return sum;
        }
        static int AliveCells (int[,]matrix)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
