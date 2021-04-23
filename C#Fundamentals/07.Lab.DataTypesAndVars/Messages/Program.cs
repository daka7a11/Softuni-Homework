using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string word = string.Empty;
            for (int i = 0; i < num; i++)
            {
                int button=int.Parse(Console.ReadLine());
                if (button==2)
                {
                    word += "a";
                }
                else if (button==22)
                {
                    word += "b";
                }
                else if (button == 222)
                {
                    word += "c";
                }
                else if (button == 3)
                {
                    word += "d";
                }
                else if (button == 33)
                {
                    word += "e";
                }
                else if (button == 333)
                {
                    word += "f";
                }
                else if (button == 4)
                {
                    word += "g";
                }
                else if (button == 44)
                {
                    word += "h";
                }
                else if (button == 444)
                {
                    word += "i";
                }
                else if (button == 5)
                {
                    word += "j";
                }
                else if (button == 55)
                {
                    word += "k";
                }
                else if (button == 555)
                {
                    word += "l";
                }
                else if (button == 6)
                {
                    word += "m";
                }
                else if (button == 66)
                {
                    word += "n";
                }
                else if (button == 666)
                {
                    word += "o";
                }
                else if (button == 7)
                {
                    word += "p";
                }
                else if (button == 77)
                {
                    word += "q";
                }
                else if (button == 777)
                {
                    word += "r";
                }
                else if (button == 7777)
                {
                    word += "s";
                }
                else if (button == 8)
                {
                    word += "t";
                }
                else if (button == 88)
                {
                    word += "u";
                }
                else if (button == 888)
                {
                    word += "v";
                }
                else if (button == 9)
                {
                    word += "w";
                }
                else if (button == 99)
                {
                    word += "x";
                }
                else if (button == 999)
                {
                    word += "y";
                }
                else if (button == 9999)
                {
                    word += "z";
                }
                else if (button == 0)
                {
                    word += " ";
                }
            }
            Console.WriteLine(word);
        }
    }
}
