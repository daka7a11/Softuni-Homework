using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] command = input.Split();
                if (command[0].ToLower() == "exchange")
                {
                    ExchangeIndex(arr, int.Parse(command[1]));
                }
                else if (command[0].ToLower() == "max")
                {
                    MaxEvenOrOddIndex(arr, command[1].ToLower());
                }
                else if (command[0].ToLower() == "min")
                {
                    MinEvenOrOddIndex(arr, command[1].ToLower());
                }
                else if (command[0].ToLower() == "first")
                {
                    FirstEvenOrOddNumbers(arr, int.Parse(command[1]), command[2].ToLower());
                }
                else if (command[0].ToLower() == "last")
                {
                    LastEvenOrOddNumbers(arr, int.Parse(command[1]), command[2].ToLower());
                }
            }
            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.Write("]");
        }
        static void ExchangeIndex(int[] arr, int index)
        {
            if (index < 0 || index > arr.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            int[] firstArr = new int[arr.Length - index - 1];
            int[] secondArr = new int[index + 1];
            int firstArrCounter = 0;
            for (int i = index + 1; i < arr.Length; i++)
            {
                firstArr[firstArrCounter] = arr[i];
                firstArrCounter++;
            }
            for (int i = 0; i <= index; i++)
            {
                secondArr[i] = arr[i];
            }
            for (int i = 0; i < firstArr.Length; i++)
            {
                arr[i] = firstArr[i];
            }
            for (int i = 0; i < secondArr.Length; i++)
            {
                arr[firstArr.Length + i] = secondArr[i];
            }
        }
        static void MaxEvenOrOddIndex(int[] arr, string operation)
        {
            int maxIndex = int.MinValue;
            int counter = 0;
            operation = operation.ToLower();
            int maxNumber = int.MinValue;
            if (operation == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 && arr[i] >= maxNumber)
                    {
                        maxIndex = i;
                        maxNumber = arr[i];
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    Console.WriteLine(maxIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
                counter = 0;
            }
            else if (operation == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0 && arr[i] >= maxNumber)
                    {
                        maxIndex = i;
                        maxNumber = arr[i];
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    Console.WriteLine(maxIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
                counter = 0;
            }
        }
        static void MinEvenOrOddIndex(int[] arr, string operation)
        {
            int minIndex = int.MaxValue;
            int counter = 0;
            operation = operation.ToLower();
            int minNumber = int.MaxValue;
            if (operation == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 && arr[i] <= minNumber)
                    {
                        minIndex = i;
                        minNumber = arr[i];
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    Console.WriteLine(minIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
                counter = 0;
            }
            else if (operation == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0 && arr[i] <= minNumber)
                    {
                        minIndex = i;
                        minNumber = arr[i];
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    Console.WriteLine(minIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
                counter = 0;
            }
        }
        static void FirstEvenOrOddNumbers(int[] arr, int n, string operation)
        {
            if (n > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            string numbers = string.Empty;
            if (operation == "even")
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                       numbers += arr[i] + " ";
                        count++;
                    }
                    if (count==n)
                    {
                        break;
                    }
                }
                string[] newArray = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (count > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", newArray) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
            else if (operation == "odd")
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        numbers += arr[i] + " ";
                        count++;
                    }
                    if (count == n)
                    {
                        break;
                    }
                }
                string[] newArray = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (count > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", newArray) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }

        }
        static void LastEvenOrOddNumbers(int[] arr, int n, string operation)
        {
            if (n > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            string numbers = string.Empty;
            if (operation == "even")
            {
                int count = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (count >= n)
                    {
                        break;
                    }
                    if (arr[i] % 2 == 0)
                    {
                       numbers+= arr[i]+" ";
                        count++;
                    }
                }
                string[] newArray = numbers.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (count > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", newArray.Reverse()) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
            else if (operation == "odd")
            {
                int count = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (count >= n)
                    {
                        break;
                    }
                    if (arr[i] % 2 != 0)
                    {
                        numbers += arr[i] + " ";
                        count++;
                    }
                }
                string[] newArray = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (count > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", newArray.Reverse()) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
        }
    }
}
