using System;
using System.Numerics;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string leftNumAsText = string.Empty;
                string rightNumAsText = string.Empty;
                bool isLeft = true;
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j].ToString() == "-")
                    {

                        continue;
                    }
                    if (input[j].ToString() == " ")
                    {
                        isLeft = false;
                        continue;
                    }
                    if (isLeft)
                    {
                        leftNumAsText += input[j].ToString();
                    }
                    else
                    {
                        rightNumAsText += input[j].ToString();
                    }
                }
                BigInteger leftNum = BigInteger.Parse(leftNumAsText);
                BigInteger rightNum = BigInteger.Parse(rightNumAsText);
                BigInteger biggestNum = 0;
                double sum = 0;
                if (leftNum>rightNum)
                {
                    biggestNum = leftNum;
                }
                else
                {
                    biggestNum = rightNum;
                }
                while (biggestNum>0)
                {
                    sum += (double)biggestNum % 10;
                    biggestNum /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}