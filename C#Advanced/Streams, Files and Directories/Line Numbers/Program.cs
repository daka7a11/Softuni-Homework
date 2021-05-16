using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] result = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];
                result[i] = $"Line {i + 1}: {currLine} ({GetCountLetterPerLine(currLine)})({GetCountPuncMarksPerLine(currLine)})";
            }
            File.WriteAllLines("../../../output.txt", result);
        }

         static object GetCountPuncMarksPerLine(string line)
        {
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (!Char.IsLetterOrDigit(line[i]) && !Char.IsWhiteSpace(line[i]))
                {
                    count++;
                }
            }
            return count;
        }

        static int GetCountLetterPerLine(string line)
        {
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsLetter(line[i]))
                {
                    count++;
                }
            }
            return count;
        }
        
    }
}
