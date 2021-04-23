using System;

namespace _1._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int attendancePerH = int.Parse(Console.ReadLine());
            attendancePerH += int.Parse(Console.ReadLine());
            attendancePerH += int.Parse(Console.ReadLine());
            int questions = int.Parse(Console.ReadLine());
            int workingHours = 0;
            while (questions>0)
            {
                workingHours++;
                if (workingHours%4==0)
                {
                    workingHours++;
                }
                questions -= attendancePerH;
            }
            Console.WriteLine($"Time needed: {workingHours}h.");
        }
    }
}
