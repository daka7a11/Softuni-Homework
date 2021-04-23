using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
                matrix[row] = new double[numbers.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = numbers[col];
                }
            }
            for (int row = 0; row < matrix.Length-1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int currRow = row; currRow <= row + 1; currRow++)
                    {
                        for (int col = 0; col < matrix[currRow].Length; col++)
                        {
                            matrix[currRow][col] *= 2;
                        }
                    }
                }
                else
                {
                    for (int currRow = row; currRow <= row + 1; currRow++)
                    {
                        for (int col = 0; col < matrix[currRow].Length; col++)
                        {
                            matrix[currRow][col] /= 2;
                        }
                    }
                }
            }
            string[] tokens = Console.ReadLine().Split();
            while (tokens[0].ToLower()!="end")
            {
                if (tokens.Length!=4)
                {
                    tokens = Console.ReadLine().Split();
                    continue;
                }
                string command = tokens[0].ToLower();
                int cmdRow = int.Parse(tokens[1]);
                int cmdCol = int.Parse(tokens[2]);
                int num = int.Parse(tokens[3]);
                if (cmdRow<0 || cmdRow>=matrix.Length)
                {
                    tokens = Console.ReadLine().Split();
                    continue;
                }
                if (cmdCol<0 || cmdCol >= matrix[cmdRow].Length)
                {
                    tokens = Console.ReadLine().Split();
                    continue;
                }
                if (command=="add")
                {
                    matrix[cmdRow][cmdCol] += num;
                }
                else if (command=="subtract")
                {
                    matrix[cmdRow][cmdCol] -= num;

                }
                tokens = Console.ReadLine().Split();
            }
            foreach (var arr in matrix)
            {
                Console.Write(string.Join(" ",arr));
                Console.WriteLine();
            }
        }
    }
}
