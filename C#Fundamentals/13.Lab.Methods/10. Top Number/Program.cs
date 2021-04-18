using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            TopNumbers(n);
        }
        static void TopNumbers(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                int currDigits = i;
                int currSum = 0;
                int oddDigitCount = 0;
                while (currDigits > 0)
                {
                    int lastDigit = currDigits % 10;
                    currDigits /= 10;
                    if (lastDigit % 2 != 0)
                    {
                        oddDigitCount++;
                    }
                    currSum += lastDigit;
                }
                if (oddDigitCount>0)
                {
                    if (currSum % 8 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
