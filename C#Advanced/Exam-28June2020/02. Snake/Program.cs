using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int snakeRow = GetSnakePosition(matrix)[0];
            int snakeCol = GetSnakePosition(matrix)[1];
            int foodEaten = 0;
            bool isSnakeGoesOut = false;
            while (true)
            {
                if (isSnakeGoesOut)
                {
                    break;
                }
                if (foodEaten==10)
                {
                    break;
                }
                string input = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                if (input == "up")
                {
                    snakeRow--;
                    Move(ref matrix, ref snakeRow, ref snakeCol, ref foodEaten, ref isSnakeGoesOut);
                }
                else if (input == "right")
                {
                    snakeCol++;
                    Move(ref matrix, ref snakeRow, ref snakeCol, ref foodEaten, ref isSnakeGoesOut);
                }
                else if (input == "down")
                {
                    snakeRow++;
                    Move(ref matrix, ref snakeRow, ref snakeCol, ref foodEaten, ref isSnakeGoesOut);
                }
                else if (input == "left")
                {
                    snakeCol--;
                    Move(ref matrix, ref snakeRow, ref snakeCol, ref foodEaten, ref isSnakeGoesOut);
                }
            }
            if (foodEaten>=10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else if (isSnakeGoesOut)
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix);
        }
        static int[] GetSnakePosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        return new int[] { row, col };
                    }
                }
            }
            return new int[2];
        }
        static bool IsThereBurrows(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int[] GetBurrows(char[,] matrix)
        {
            int[] firstBurrowPositions = new int[2];
            firstBurrowPositions[0] = -1;
            int[] secondBurrowPositions = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (firstBurrowPositions[0] == -1)
                        {
                            firstBurrowPositions[0] = row;
                            firstBurrowPositions[1] = col;
                        }
                        else
                        {
                            secondBurrowPositions[0] = row;
                            secondBurrowPositions[1] = col;
                        }

                    }
                }
            }
            return new int[] { firstBurrowPositions[0], firstBurrowPositions[1], secondBurrowPositions[0], secondBurrowPositions[1] };
        }
        static bool IsInTheTerritory(char[,]matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        static void PrintMatrix(char[,] matrix)
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
        static void Move(ref char[,]matrix, ref int row, ref int col, ref int foodEaten, ref bool isSnakeGoesOut)
        {
            int firstBurrowRow = 0;
            int firstBurrowCol = 0;
            int secondBurrowRow = 0;
            int secondBurrowCol = 0;
            if (IsThereBurrows(matrix))
            {
                firstBurrowRow = GetBurrows(matrix)[0];
                firstBurrowCol = GetBurrows(matrix)[1];
                secondBurrowRow = GetBurrows(matrix)[2];
                secondBurrowCol = GetBurrows(matrix)[3];
            }
            if (IsInTheTerritory(matrix, row, col))
            {
                if (matrix[row, col] == '-')
                {
                    matrix[row, col] = 'S';
                }
                else if (matrix[row, col] == '*')
                {
                    matrix[row, col] = 'S';
                    foodEaten++;
                }
                else if (matrix[row, col] == 'B')
                {
                    if (firstBurrowRow == row && firstBurrowCol == col)
                    {
                        matrix[row, col] = '.';
                        row = secondBurrowRow;
                        col = secondBurrowCol;
                        matrix[row, col] = 'S';
                    }
                }
            }
            else
            {
                isSnakeGoesOut = true;
            }
        }
    }
}
