using System;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "dsabhgfd";
            a=a.Replace("dsa","*****");
            Console.WriteLine(a);
        }
    }
}
