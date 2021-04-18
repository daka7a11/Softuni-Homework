using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Lesson";
            string b = "Lesson-Exercise";

            if (a+"-Exercise"==b)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
