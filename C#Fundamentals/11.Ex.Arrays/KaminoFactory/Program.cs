using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int bestLength = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int sequenceCounter = 0;
            int bestSequenceIndex = 0;
            int[] array = new int[n];
            while (input!="Clone them!")
            {
                int[] arr = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sequenceCounter++;
                int length = 1;
                int bestCurrLength = 1;
                int startIndex = 0;
                int currSequenceSum = 0;
                for (int i = 0; i < arr.Length-1; i++)
                {
                    if (arr[i]==arr[i+1])
                    {
                        length++;
                    }
                    else
                    {
                        length = 1;
                    }
                    if (length>bestCurrLength)
                    {
                        bestCurrLength = length;
                        startIndex = i;
                    }
                    currSequenceSum += arr[i];
                }
                currSequenceSum += arr[arr.Length-1];
                if (bestCurrLength>bestLength)
                {
                    bestLength = bestCurrLength;
                    bestStartIndex = startIndex;
                    bestSequenceSum = currSequenceSum;
                    bestSequenceIndex = sequenceCounter;
                    array = arr.ToArray();
                }
                else if (bestCurrLength==bestLength)
                {
                    if (startIndex<bestStartIndex)
                    {
                        bestLength = bestCurrLength;
                        bestStartIndex = startIndex;
                        bestSequenceSum = currSequenceSum;
                        bestSequenceIndex = sequenceCounter;
                        array = arr.ToArray();
                    }
                    else if (startIndex==bestStartIndex)
                    {
                        if (currSequenceSum>bestSequenceSum)
                        {
                            bestLength = bestCurrLength;
                            bestStartIndex = startIndex;
                            bestSequenceSum = currSequenceSum;
                            bestSequenceIndex = sequenceCounter;
                            array = arr.ToArray();
                        }
                    }
                }
                array = arr.ToArray();

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
