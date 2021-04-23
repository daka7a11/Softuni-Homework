using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input!="END")
            {
                bool isInt = int.TryParse(input, out int intOut);
                bool isFloat = float.TryParse(input, out float floatOut);
                bool isChar = char.TryParse(input, out char charOut);
                bool isBool = bool.TryParse(input, out bool boolOut);
                if (isInt)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (isFloat)
                {
                    Console.WriteLine($"{input} is floating point type");

                }
                else if (isChar)
                {
                    Console.WriteLine($"{input} is character type");

                }
                else if (isBool)
                {
                    Console.WriteLine($"{input} is boolean type");

                }
                else
                {
                    Console.WriteLine($"{input} is string type");

                }
                input = Console.ReadLine();
            }
        }
    }
}
