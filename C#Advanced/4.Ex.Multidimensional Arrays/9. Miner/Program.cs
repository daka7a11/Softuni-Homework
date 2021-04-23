using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];
            FillingMatrix(matrix);
            int[] startLocation = FindStart(matrix);
            int row = startLocation[0];
            int col = startLocation[1];
            int colectedCoal = 0;
            int totalCoal = CoalCount(matrix);
            for (int i = 0; i < commands.Length; i++)
            {
                string currCommand = commands[i];
                if (currCommand=="up")
                {
                    if (IsMoveInField(matrix,row-1,col))
                    {
                        row--;
                    }
                }
                else if (currCommand=="right")
                {
                    if (IsMoveInField(matrix, row , col + 1))
                    {
                        col++;
                    }
                }
                else if (currCommand == "down")
                {
                    if (IsMoveInField(matrix, row + 1, col))
                    {
                        row++;
                    }
                }
                else if (currCommand == "left")
                {
                    if (IsMoveInField(matrix, row, col-1))
                    {
                        col--;
                    }
                }
                if (matrix[row,col]=='e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
                else if (matrix[row,col]=='c')
                {
                    colectedCoal++;
                    matrix[row, col] = '*';
                    if (colectedCoal==totalCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{totalCoal-colectedCoal} coals left. ({row}, {col})");
        }
        static void FillingMatrix(char[,] matrix)
        {
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] field = Console.ReadLine()
                              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(char.Parse)
                              .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = field[col];
                }
            }
        }
        static bool IsMoveInField(char[,]matrix,int row,int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        static int[] FindStart(char[,] matrix)
        {
            int[] arr = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]=='s')
                    {
                        arr[0] = row;
                        arr[1] = col;
                    }
                }
            }
            return arr;
        }
        static int CoalCount(char[,]matrix)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}
