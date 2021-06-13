using System;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int marioRow = GetMarioPosition(matrix)[0];
            int marioCol = GetMarioPosition(matrix)[1];
            bool isMarioWon = false;
            while (health > 0)
            {
                if (isMarioWon)
                {
                    break;
                }
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char command = char.Parse(input[0]);
                int currRow = int.Parse(input[1]);
                int currCol = int.Parse(input[2]);
                matrix[currRow, currCol] = 'B';
                health--;
                if (health<=0)
                {
                    matrix[marioRow, marioCol] = 'X';
                    break;
                }
                if (command == 'W')
                {
                    if (IsInMatrix(matrix, marioRow - 1, marioCol))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioRow--;
                        Move(ref matrix, ref marioRow, ref marioCol, ref isMarioWon, ref health);
                    }
                }
                else if (command == 'D')
                {
                    if (IsInMatrix(matrix, marioRow, marioCol + 1))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioCol++;
                        Move(ref matrix, ref marioRow, ref marioCol, ref isMarioWon, ref health);
                    }
                }
                else if (command == 'S')
                {
                    if (IsInMatrix(matrix, marioRow + 1, marioCol))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioRow++;
                        Move(ref matrix, ref marioRow, ref marioCol, ref isMarioWon, ref health);
                    }
                }
                else if (command == 'A')
                {
                    if (IsInMatrix(matrix, marioRow, marioCol - 1))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioCol--;
                        Move(ref matrix, ref marioRow, ref marioCol, ref isMarioWon, ref health);
                    }
                }
                Console.WriteLine(health);
                PrintMatrix(matrix);
            }
            if (health > 0)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }
            PrintMatrix(matrix);
        }
        static void Move(ref char[,] matrix, ref int row, ref int col, ref bool isMarioWon, ref int health)
        {
            if (matrix[row, col] == '-')
            {
                matrix[row, col] = 'M';
            }
            else if (matrix[row, col] == 'P')
            {
                matrix[row, col] = '-';
                isMarioWon = true;
            }
            else if (matrix[row, col] == 'B')
            {
                health -= 2;
                if (health <= 0)
                {
                    matrix[row, col] = 'X';
                    return;
                }
                matrix[row, col] = 'M';
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

        static int[] GetMarioPosition(char[,] matrix)
        {
            int[] position = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        position[0] = row;
                        position[1] = col;
                        return position;
                    }
                }
            }
            return position;
        }

        static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

    }
}
