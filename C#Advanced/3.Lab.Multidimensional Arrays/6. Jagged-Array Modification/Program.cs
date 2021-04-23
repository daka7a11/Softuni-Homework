using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = new int[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
            string[] command = Console.ReadLine().Split();
            while (command[0].ToLower()!="end")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int num = int.Parse(command[3]);
                if (!((row>=0 && row < matrix.Length)&&(col>=0 && col<matrix[row].Length)))
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine().Split();
                    continue;
                }
                if (command[0].ToLower()=="add")
                {
                    matrix[row][col] += num;
                }
                else if (command[0].ToLower() == "subtract")
                {
                    matrix[row][col] -= num;
                }
                command = Console.ReadLine().Split();
            }
            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
        }
    }
}
