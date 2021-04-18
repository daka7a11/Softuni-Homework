using System;
using System.Linq;
namespace _3.__Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(@"\",StringSplitOptions.RemoveEmptyEntries);
            string[] result = input.Last().Split(".",StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"File name: {result[0]}");
            Console.WriteLine($"File extension: {result[1]}");
        }
    }
}
