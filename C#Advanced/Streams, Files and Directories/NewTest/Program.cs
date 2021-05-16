using System;
using System.IO;

namespace NewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Console.WriteLine(GetDirectorySize(path));
        }
        static double GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path);
            double sum = 0;

            string[] directories = Directory.GetDirectories(path);
            for (int i = 0; i < directories.Length; i++)
            {
                sum += GetDirectorySize(directories[i]);
            }
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                Console.WriteLine($"{info.FullName}  --> {info.Length} bytes");
                sum += info.Length;
            }
            return sum;
        }
    }
}

