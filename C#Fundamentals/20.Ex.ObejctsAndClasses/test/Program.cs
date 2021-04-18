using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Articles
{

    class Program
    {
        static void Main(string[] args)
        {
            List<string> a = new List<string> {"a","b","c","d","e","f"};
            if (a.Contains("a"))
            {
                int index = a.FindIndex(x => x == "c");
                Console.WriteLine(a[index]);
            }
        }
    }
}
