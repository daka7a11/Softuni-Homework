using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                if (input.Length==4)
                {
                    string id = input[2];
                    string birthdate = input[3];
                    Citizen citizen = new Citizen(name,age,id,birthdate);
                    buyers.Add(citizen);
                }
                else if (input.Length==3)
                {
                    string group = input[2];
                    Rebel rebel = new Rebel(name,age,group);
                    buyers.Add(rebel);
                }
            }
            string buyerName = default;
            while ((buyerName = Console.ReadLine().Replace(" ", string.Empty)).ToLower() != "end")
            {
                IBuyer buyer = buyers.FirstOrDefault(x => x.Name == buyerName);
                if (buyer!=null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
