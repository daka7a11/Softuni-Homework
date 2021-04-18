using System;

public class Program
{
	public static void Main()
	{
		string username = Console.ReadLine();
		string pass = string.Empty;
		int count = 0;
		for (int i = username.Length - 1; i >= 0; i--)
		{
			pass += username[i];
		}
		string input = Console.ReadLine();
		while (input != pass)
		{
			count++;
			if (count == 4)
			{
				Console.WriteLine($"User {username} blocked!");
				break;
			}
			Console.WriteLine("Incorrect password. Try again.");
			input = Console.ReadLine();
		}
		if (input == pass)
		{
			Console.WriteLine($"User {username} logged in.");
		}
	}
}