using System;
using System.Collections.Generic;

namespace _3._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> listOfSongs = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("_");
                Song currSong = new Song();
                currSong.TypeList = input[0];
                currSong.Name = input[1];
                currSong.Time = input[2];
                listOfSongs.Add(currSong);
            }
            string printType = Console.ReadLine();
            if (printType=="all")
            {
                foreach (var x in listOfSongs)
                {
                    Console.WriteLine(x.Name);
                }
            }
            else
            {
                foreach (var x in listOfSongs)
                {
                    if (x.TypeList==printType)
                    {
                        Console.WriteLine(x.Name);
                    }
                }
            }
        }
    }
}
