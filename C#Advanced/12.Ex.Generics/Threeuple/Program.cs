using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personInformation = Console.ReadLine().Split();
            string personFullName = $"{personInformation[0]} {personInformation[1]}";
            string address = personInformation[2];
            string town = string.Empty;
            for (int i = 3; i < personInformation.Length; i++)
            {
                if (i+1==personInformation.Length)
                {
                    town += $"{personInformation[i]}";
                }
                else
                {
                    town += $"{personInformation[i]} ";

                }
            }
            Threeuple<string, string, string> firstPerson = new Threeuple<string, string, string>(personFullName, address, town);
            Console.WriteLine(firstPerson);

            personInformation = Console.ReadLine().Split();
            string personName = personInformation[0];
            int litersOfBeer = int.Parse(personInformation[1]);
            bool isDrunk = personInformation[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> secondPerson = new Threeuple<string, int, bool>(personName, litersOfBeer, isDrunk);
            Console.WriteLine(secondPerson);

            string[] lastInput = Console.ReadLine().Split();
            string pName = lastInput[0];
            double balance = double.Parse(lastInput[1]);
            string bankName = lastInput[2];
            Threeuple<string, double, string> thirdPerson = new Threeuple<string, double, string>(pName, balance,bankName);
            Console.WriteLine(thirdPerson);
        }
    }
}
