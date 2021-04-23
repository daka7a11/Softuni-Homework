using System;
using System.Linq;

namespace ReverseArrOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ",Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()));
        }
    }
}
