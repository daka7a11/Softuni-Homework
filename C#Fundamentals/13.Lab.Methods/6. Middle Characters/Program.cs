using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            MiddleChars(text);
        }
        static void MiddleChars(string text)
        {
            int a = text.Length / 2;
            if (text.Length%2==0)
            {
                Console.Write(text[a-1].ToString());
                Console.Write(text[a].ToString());

            }
            else
            {
                Console.WriteLine(text[a].ToString());
            }
        }
    }
}
