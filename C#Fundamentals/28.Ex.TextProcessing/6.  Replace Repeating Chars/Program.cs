using System;
using System.Text;
using System.Linq;
namespace _6.__Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int i = 1;
            StringBuilder result = new StringBuilder();
            result.Append(input[0]);
            while (i < input.Length)
            {
                if (input[i]!=result[result.Length-1])
                {
                    result.Append(input[i]);
                }
                i++;
            }
            Console.WriteLine(result);
        }
    }
}
