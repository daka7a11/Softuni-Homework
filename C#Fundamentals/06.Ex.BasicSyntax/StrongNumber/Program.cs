using System;

public class Program
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string numText = num.ToString();
        int sum = 1;
        int totalSum = 0;
        int currDigit = 0;
        for (int i = 0; i <= numText.Length - 1; i++)
        {
            currDigit = int.Parse(numText[i].ToString());
            for (int j = 1; j <= currDigit; j++)
            {
                sum *= j;
            }
            totalSum += sum;
            sum = 1;
        }
        if (num == totalSum)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}