using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            string direction = "right";
            int row = 0;
            int col = 0;
            for (int i = 1; i <= size*size; i++)
            {
                matrix[row, col] = i;
                if (direction=="right")
                {
                    col++;
                    if (col==size || matrix[row, col] != 0)
                    {
                        direction = "down";
                        col--;
                    }
                }
                if (direction=="down")
                {
                    row++;
                    if (row==size || matrix[row, col] != 0)
                    {
                        direction = "left";
                        row--;
                    }
                }
                if (direction=="left")
                {
                    col--;
                    if (col==-1 || matrix[row, col] != 0)
                    {
                        direction = "up";
                        col++;
                    }
                }
                if (direction=="up")
                {
                    row--;
                    if (row==-1 || matrix[row,col]!=0)
                    {
                        direction = "right";
                        row++;
                        col++;
                    }
                }
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows,cols]<10)
                    {
                    Console.Write("  "+matrix[rows,cols]);
                    }
                    else
                    {
                        Console.Write(" "+matrix[rows, cols]);

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
