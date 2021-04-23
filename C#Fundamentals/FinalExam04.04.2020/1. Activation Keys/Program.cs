using System;
using System.Text;
using System.Linq;
namespace _1._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            string[] input = Console.ReadLine().Split(">>>",StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower()!="generate")
            {
                string instruction = input[0];
                if (instruction.ToLower()=="contains")
                {
                    string substring = input[1];
                    if (sb.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{sb} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (instruction.ToLower()=="flip")
                {
                    string lettersCommand = input[1].ToLower();
                    int startIndex = int.Parse(input[2]);
                    int endIndex = int.Parse(input[3]);
                    string substringToChange = string.Empty;
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        substringToChange += sb[i];
                    }

                    if (lettersCommand=="upper")
                    {
                        sb.Replace(substringToChange, substringToChange.ToUpper());
                    }
                    else if (lettersCommand=="lower")
                    {
                        sb.Replace(substringToChange, substringToChange.ToLower());
                    }
                    Console.WriteLine(sb);
                }
                else if (instruction.ToLower()=="slice")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    sb.Remove(startIndex,endIndex-startIndex);
                    Console.WriteLine(sb);
                }
                input = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your activation key is: {sb}");
        }
    }
}
