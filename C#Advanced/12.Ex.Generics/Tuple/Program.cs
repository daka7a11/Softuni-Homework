using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personInformation = Console.ReadLine().Split();
            string personFullName = $"{personInformation[0]} {personInformation[1]}";
            string address = personInformation[2];
            Tuple<string, string> firstPerson = new Tuple<string, string>(personFullName,address);
            Console.WriteLine(firstPerson);

            personInformation = Console.ReadLine().Split();
            string personName = personInformation[0];
            int litersOfBeer = int.Parse(personInformation[1]);
            Tuple<string, int> secondPerson = new Tuple<string, int>(personName,litersOfBeer);
            Console.WriteLine(secondPerson);

            string[] lastInput = Console.ReadLine().Split();
            int firstNumber = int.Parse(lastInput[0]);
            double secondNumber = double.Parse(lastInput[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(firstNumber,secondNumber);
            Console.WriteLine(numbers);
        }
    }
}
