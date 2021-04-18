using System;

public class Program
{
	public static void Main()
	{
		string coin = Console.ReadLine();
		coin = coin.ToLower();
		double currCoin = 0;
		double sum = 0;
		while (coin != "start")
		{
			currCoin = double.Parse(coin);
			if (currCoin == 2 || currCoin == 2.0)
			{
				sum += 2;
			}
			else if (currCoin == 1 || currCoin == 1.0)
			{
				sum += 1;
			}
			else if (currCoin == 0.5)
			{
				sum += 0.5;
			}
			else if (currCoin == 0.2)
			{
				sum += 0.2;
			}
			else if (currCoin == 0.1)
			{
				sum += 0.1;
			}
			else
			{
				Console.WriteLine($"Cannot accept {currCoin}");
			}
			coin = Console.ReadLine();
			coin = coin.ToLower();
		}
		string product = Console.ReadLine();
		product = product.ToLower();
		while (product != "end")
		{
			if (product == "nuts")
			{
				if (sum < 2)
				{
					Console.WriteLine("Sorry, not enough money");
				}
				else
				{
					sum -= 2;
					Console.WriteLine("Purchased nuts");
				}
			}
			else if (product == "water")
			{
				if (sum < 0.7)
				{
					Console.WriteLine("Sorry, not enough money");
				}
				else
				{
					sum -= 0.7;
					Console.WriteLine("Purchased water");
				}
			}
			else if (product == "crisps")
			{
				if (sum < 1.5)
				{
					Console.WriteLine("Sorry, not enough money");
				}
				else
				{
					sum -= 1.5;
					Console.WriteLine("Purchased crisps");
				}
			}
			else if (product == "soda")
			{
				if (sum < 0.8)
				{
					Console.WriteLine("Sorry, not enough money");
				}
				else
				{
					sum -= 0.8;
					Console.WriteLine("Purchased soda");
				}
			}
			else if (product == "coke")
			{
				if (sum < 1)
				{
					Console.WriteLine("Sorry, not enough money");
				}
				else
				{
					sum -= 1;
					Console.WriteLine("Purchased coke");
				}
			}
			else
			{
				Console.WriteLine("Invalid product");
			}
			product = Console.ReadLine();
			product = product.ToLower();
		}
		Console.WriteLine($"Change: {sum:F2}");
	}
}