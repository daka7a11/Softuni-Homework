using System;
using System.Collections.Generic;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();
            string input = Console.ReadLine();
            while (input!="PARTY")
            {
                bool isVip = Char.IsDigit(input[0]);
                if (isVip)
                {
                    vips.Add(input);
                }
                else
                {
                    regulars.Add(input);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!="END")
            {
                bool isVip = Char.IsDigit(input[0]);
                if (isVip)
                {
                    vips.Remove(input);
                }
                else
                {
                    regulars.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(vips.Count + regulars.Count);
            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }
            foreach (var regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
