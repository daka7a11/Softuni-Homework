using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[coordinates[0], coordinates[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            bool IsPlayerWon = false;
            bool IsPlayerDead = false;
            string commands = Console.ReadLine().ToUpper();
            int playerRow = FindPlayerCoordinates(matrix)[0];
            int playerCol = FindPlayerCoordinates(matrix)[1];
            for (int i = 0; i < commands.Length; i++)
            {
                char currCommand = commands[i];
                if (currCommand == 'U')
                {
                    if (IsInMatrix(matrix, playerRow - 1, playerCol))
                    {
                        if (matrix[playerRow - 1, playerCol] == 'B')
                        {
                            IsPlayerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerRow--;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow - 1, playerCol] = 'P';
                            playerRow--;
                        }
                    }
                    else
                    {
                        IsPlayerWon = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                else if (currCommand == 'R')
                {
                    if (IsInMatrix(matrix, playerRow, playerCol + 1))
                    {
                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            IsPlayerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerCol++;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow, playerCol + 1] = 'P';
                            playerCol++;
                        }
                    }
                    else
                    {
                        IsPlayerWon = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                else if (currCommand == 'D')
                {
                    if (IsInMatrix(matrix, playerRow + 1, playerCol))
                    {
                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            IsPlayerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerRow--;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow + 1, playerCol] = 'P';
                            playerRow++;
                        }
                    }
                    else
                    {
                        IsPlayerWon = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                else if (currCommand == 'L')
                {
                    if (IsInMatrix(matrix, playerRow, playerCol - 1))
                    {
                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            IsPlayerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerCol--;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow, playerCol - 1] = 'P';
                            playerCol--;
                        }
                    }
                    else
                    {
                        IsPlayerWon = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                Queue<int[]> queue = BCoordinatesToClone(matrix);
                while (queue.Count > 0)
                {
                    int[] currBunnyCoordinates = queue.Dequeue();
                    int currBunnyRow = currBunnyCoordinates[0];
                    int currBunnyCol = currBunnyCoordinates[1];
                    if (IsInMatrix(matrix, currBunnyRow - 1, currBunnyCol)) // SPREAD B TO THE UP
                    {
                        if (matrix[currBunnyRow - 1, currBunnyCol] == 'P')
                        {
                            IsPlayerDead = true;
                        }
                        matrix[currBunnyRow - 1, currBunnyCol] = 'B';
                    }
                    if (IsInMatrix(matrix, currBunnyRow, currBunnyCol + 1)) // SPREAD B TO THE RIGHT
                    {
                        if (matrix[currBunnyRow, currBunnyCol + 1] == 'P')
                        {
                            IsPlayerDead = true;
                        }
                        matrix[currBunnyRow, currBunnyCol + 1] = 'B';
                    }
                    if (IsInMatrix(matrix, currBunnyRow + 1, currBunnyCol)) // SPREAD B TO THE DOWN
                    {
                        if (matrix[currBunnyRow + 1, currBunnyCol] == 'P')
                        {
                            IsPlayerDead = true;
                        }
                        matrix[currBunnyRow + 1, currBunnyCol] = 'B';
                    }
                    if (IsInMatrix(matrix, currBunnyRow, currBunnyCol - 1)) // SPREAD B TO THE LEFT
                    {
                        if (matrix[currBunnyRow, currBunnyCol - 1] == 'P')
                        {
                            IsPlayerDead = true;
                        }
                        matrix[currBunnyRow, currBunnyCol - 1] = 'B';
                    }
                }
                if (IsPlayerWon || IsPlayerDead)
                {
                    break;
                }
            }
            PrintMatrix(matrix);
            if (IsPlayerWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (IsPlayerDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
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
        static int[] FindPlayerCoordinates(char[,] matrix)
        {
            int[] coordinates = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                        return coordinates;
                    }
                }
            }
            return coordinates;
        }
        static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        static Queue<int[]> BCoordinatesToClone(char[,] matrix)
        {
            int[] arr = new int[2];
            Queue<int[]> queue = new Queue<int[]>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        queue.Enqueue(new int[] { row, col });
                    }
                }
            }
            return queue;
        }
    }
}
