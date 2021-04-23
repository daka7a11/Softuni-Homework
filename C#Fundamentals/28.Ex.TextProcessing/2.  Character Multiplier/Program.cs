using System;

namespace _2.__Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(MultiplyStringChars(input[0],input[1]));
        }
        static double MultiplyStringChars(string str1, string str2)
        {
            double sum = 0;
            if (str1.Length==str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += str1[i] * str2[i];
                }
            }
            else if (str1.Length > str2.Length)
            {
                for (int i = 0; i < str2.Length; i++)
                { 
                    sum += str1[i] * str2[i];
                }
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    sum += str1[i];
                }
            }
            else if (str1.Length < str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += str1[i] * str2[i];
                }
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    sum += str2[i];
                }
            }
            return sum;
        }
    }
}
