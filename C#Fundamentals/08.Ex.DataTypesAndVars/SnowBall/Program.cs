using System;
using System.Numerics;

namespace SnowBall
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger snowballNum = int.Parse(Console.ReadLine());
            BigInteger bestValue = 0;
            BigInteger snowballSnowBest = 0;
            BigInteger snowballTimeBest = 0;
            BigInteger snowballQualityBest = 0;
            for (int i = 0; i < snowballNum; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballQuality = BigInteger.Parse(Console.ReadLine());
                BigInteger currValue = BigInteger.Pow(snowballSnow / snowballTime,(int)snowballQuality);
                if (currValue > bestValue)
                {
                    bestValue = currValue;
                    snowballSnowBest = snowballSnow;
                    snowballTimeBest = snowballTime;
                    snowballQualityBest = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnowBest} : {snowballTimeBest} = {bestValue} ({snowballQualityBest})");
        }
    }
}
