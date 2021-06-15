using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Hero hero = new BladeKnight("Yordan",10);
            Console.WriteLine(hero);
        }
    }
}