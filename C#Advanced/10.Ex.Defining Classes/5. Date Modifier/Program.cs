using System;
using System.ComponentModel.DataAnnotations;

namespace DateModifierExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();
            Console.WriteLine(Math.Abs(dateModifier.GetDayDifference(startDate, endDate)));
        }
    }
}
