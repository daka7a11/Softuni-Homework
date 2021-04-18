using System;

namespace _1.__Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in input)
            {
                int validCount = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    char currDigit = x[i];
                    if (currDigit==45 || currDigit==95 || (currDigit>=65 && currDigit<=90) || (currDigit>= 97 && currDigit <=122))
                    {
                        if (x.Length>=3 && x.Length<=16)
                        {
                        validCount++;
                        }
                    }
                }
                if (validCount==x.Length)
                {
                    Console.WriteLine(x);
                }
            }
        }
    }
}
