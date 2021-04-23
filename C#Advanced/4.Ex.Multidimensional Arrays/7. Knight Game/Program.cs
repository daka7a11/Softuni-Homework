using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimension, dimension];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int killedKnights = 0;
            while (true)
            {
                int maxAttacks = 0;
                int maxRow = 0;
                int maxCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            // CHECK FOR ATTACKS
                            int currAttacks = 0;
                            if (IsInside(matrix, row - 2, col - 1)) //UP-LEFT // 2 UP 1 LEFT 
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row - 2, col + 1)) // UP-RIGHT // 2 UP 1 RIGHT
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row - 1, col + 2)) // RIGHT-UP // 2 RIGHT 1 UP
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row + 1, col + 2)) // RIGHT-DOWN // 2 RIGHT 1 DOWN
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row + 2, col + 1)) // DOWN-RIGHT // 2 DOWN 1 RIGHT
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row + 2, col - 1)) // DOWN-LEFT // 2 DOWN 1 LEFT
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row + 1, col - 2)) // LEFT-DOWN // 2 LEFT 1 DOWN
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (IsInside(matrix, row - 1, col - 2)) // LEFT-UP // 2 LEFT 1 UP
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    currAttacks++;
                                }
                            }
                            if (currAttacks > maxAttacks)
                            {
                                maxAttacks = currAttacks;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if (maxAttacks == 0)
                {
                    break;
                }
                matrix[maxRow, maxCol] = 'O';
                killedKnights++;
            }
            Console.WriteLine(killedKnights);
        }
        static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
