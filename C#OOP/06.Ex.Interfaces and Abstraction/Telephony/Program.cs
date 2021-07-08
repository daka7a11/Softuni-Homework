using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            string[] numbers = Console.ReadLine().Split(' ');
            string[] urls = Console.ReadLine().Split(' ');
            foreach (var number in numbers)
            {
                if (IsNumberValid(number))
                {
                    if (number.Length>7)
                    {
                        smartphone.Call(number);
                    }
                    else
                    {
                        stationaryPhone.Call(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var url in urls)
            {
                if (IsUrlValid(url))
                {
                    smartphone.Browse(url);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }




            bool IsNumberValid(string number)
            {
                foreach (var ch in number)
                {
                    if (!Char.IsDigit(ch))
                    {
                        return false;
                    }
                }
                return true;
            }
            bool IsUrlValid(string url)
            {
                foreach (var ch in url)
                {
                    if (Char.IsDigit(ch))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
