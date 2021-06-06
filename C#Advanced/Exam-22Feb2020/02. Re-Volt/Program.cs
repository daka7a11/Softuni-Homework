using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int playerRow = GetStartPosition(matrix)[0];
            int playerColumn = GetStartPosition(matrix)[1];
            bool isPlayerWon = false;
            for (int i = 0; i < commandsCount; i++)
            {
                if (isPlayerWon)
                {
                    break;
                }
                string input = Console.ReadLine();
                Move(ref matrix, ref playerRow, ref playerColumn, input, ref isPlayerWon);
            }
            if (isPlayerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
        }
        static void Move(ref char[,] matrix, ref int row, ref int col, string command, ref bool isPlayerWon)
        {
            if (!(matrix[row, col]=='B'))
            {
            matrix[row, col] = '-';
            }
            if (command == "up")
            {
                if (IsInMatrix(matrix, row - 1, col))
                {
                    row--;
                }
                else
                {
                    row = matrix.GetLength(0) - 1;
                }
                if (matrix[row, col] == 'F')
                {
                    isPlayerWon = true;
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == '-')
                {
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == 'B')
                {
                    Move(ref matrix, ref row, ref col, command, ref isPlayerWon);
                }
                else if (matrix[row, col] == 'T')
                {
                    row++;
                }
            }
            else if (command == "right")
            {
                if (IsInMatrix(matrix, row, col+1))
                {
                    col++;
                }
                else
                {
                    col = 0;
                }
                if (matrix[row, col] == 'F')
                {
                    isPlayerWon = true;
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == '-')
                {
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == 'B')
                {
                    Move(ref matrix, ref row, ref col, command, ref isPlayerWon);
                }
                else if (matrix[row, col] == 'T')
                {
                    col--;
                }
            }
            else if (command == "down")
            {
                if (IsInMatrix(matrix, row+1, col))
                {
                    row++;
                }
                else
                {
                    row = 0;
                }
                if (matrix[row, col] == 'F')
                {
                    isPlayerWon = true;
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == '-')
                {
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == 'B')
                {
                    Move(ref matrix, ref row, ref col, command, ref isPlayerWon);
                }
                else if (matrix[row, col] == 'T')
                {
                    row--;
                }
            }
            else if (command == "left")
            {
                if (IsInMatrix(matrix, row, col - 1))
                {
                    col--;
                }
                else
                {
                    col = matrix.GetLength(1) - 1;
                }
                if (matrix[row, col] == 'F')
                {
                    isPlayerWon = true;
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == '-')
                {
                    matrix[row, col] = 'f';
                }
                else if (matrix[row, col] == 'B')
                {
                    Move(ref matrix, ref row, ref col, command, ref isPlayerWon);
                }
                else if (matrix[row, col] == 'T')
                {
                    col++;
                }
            }
        }
        static int[] GetStartPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        return new int[] { row, col };
                    }
                }
            }
            return new int[] { 0, 0 };
        }
        static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                 && col >= 0 && col < matrix.GetLength(1);
        }
        static void PrintMatrix(char[,]matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}