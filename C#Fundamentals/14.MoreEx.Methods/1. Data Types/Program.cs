using System;

namespace _1._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string number = Console.ReadLine();
            if (type == "int")
            {
                int num = int.Parse(number);
                DataTypes(num);
            }
            else if (type == "real")
            {
                double num = double.Parse(number);
                DataTypes(num);
            }
            else
            {
                DataTypes(number);
            }

        }
        static void DataTypes(int num)
        {
            Console.WriteLine(num*2);
        }
        static void DataTypes(double num)
        {
            Console.WriteLine($"{num*1.5:F2}");
        }
        static void DataTypes(string s)
        {
            Console.WriteLine("$" + s + "$");
        }

    }
}