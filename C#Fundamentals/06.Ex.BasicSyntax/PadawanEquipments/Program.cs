using System;

public class Program
{
	public static void Main()
	{
		double money = double.Parse(Console.ReadLine());
		int students = int.Parse(Console.ReadLine());
		double lightsabersP = double.Parse(Console.ReadLine());
		double robesP = double.Parse(Console.ReadLine());
		double beltsP = double.Parse(Console.ReadLine());
		double totalLightsabers = 0;
		double totalRobes = 0;
		double totalBelts = 0;
		double totalCost = 0;
		double tenPercent = Math.Ceiling(students * 0.10);
		int countBelt = students / 6;

		totalLightsabers = (students + tenPercent) * lightsabersP;
		totalRobes = students * robesP;
		totalBelts = students * beltsP;
		totalBelts -= countBelt * beltsP;
		totalCost = totalLightsabers + totalRobes + totalBelts;
		if (money >= totalCost)
		{
			Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
		}
		else
		{
			Console.WriteLine($"Ivan Cho will need {totalCost - money:F2}lv more.");
		}


	}
}