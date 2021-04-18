using System;
using System.Text;

namespace _4._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            foreach (var letter in input)
            {
                switch (letter)
                {
                    case "|":
                        result.Append(" ");
                        break;
                    case ".-":
                        result.Append("A");
                        break;
                    case "-...":
                        result.Append("B");
                        break;
                    case "-.-.":
                        result.Append("C");
                        break;
                    case "-..":
                        result.Append("D");
                        break;
                    case ".":
                        result.Append("E");
                        break;
                    case "..-.":
                        result.Append("F");
                        break;
                    case "--.":
                        result.Append("G");
                        break;
                    case "....":
                        result.Append("H");
                        break;
                    case "..":
                        result.Append("I");
                        break;
                    case ".---":
                        result.Append("J");
                        break;
                    case "-.-":
                        result.Append("K");
                        break;
                    case ".-..":
                        result.Append("L");
                        break;
                    case "--":
                        result.Append("M");
                        break;
                    case "-.":
                        result.Append("N");
                        break;
                    case "---":
                        result.Append("O");
                        break;
                    case ".--.":
                        result.Append("P");
                        break;
                    case "--.-":
                        result.Append("Q");
                        break;
                    case ".-.":
                        result.Append("R");
                        break;
                    case "...":
                        result.Append("S");
                        break;
                    case "-":
                        result.Append("T");
                        break;
                    case "..-":
                        result.Append("U");
                        break;
                    case "...-":
                        result.Append("V");
                        break;
                    case ".--":
                        result.Append("W");
                        break;
                    case "-..-":
                        result.Append("X");
                        break;
                    case "-.--":
                        result.Append("Y");
                        break;
                    case "--..":
                        result.Append("Z");
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
