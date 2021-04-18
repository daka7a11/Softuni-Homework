using System;

public class Program
{
	public static void Main()
	{
		int lostGame = int.Parse(Console.ReadLine());
		double headsetPrice = double.Parse(Console.ReadLine());
		double mousePrice = double.Parse(Console.ReadLine());
		double keyboardPrice = double.Parse(Console.ReadLine());
		double displayPrice = double.Parse(Console.ReadLine());
		double sum = 0;
		if (lostGame >= 2)
		{
			sum += ((int)lostGame / 2) * headsetPrice;
			if (lostGame >= 3)
			{
				sum += ((int)lostGame / 3) * mousePrice;
				if (lostGame >= 6)
				{
					sum += ((int)lostGame / 6) * keyboardPrice;
					if (lostGame >= 12)
					{
						sum += ((int)lostGame / 12) * displayPrice;
					}
				}
			}
		}
		Console.WriteLine($"Rage expenses: {sum:F2} lv.");

	}
}