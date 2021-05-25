using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower()!="tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);
                Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                if (!IsTrainerExist(trainers,trainerName))
                {
                    trainers.Add(trainer);
                }
                AddPokemon(trainers, trainerName, new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string command = Console.ReadLine();
            while (command.ToLower()!="end")
            {
                foreach (var trainer in trainers)
                {
                    int count = 0;
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element==command)
                        {
                            count++;
                        }
                    }
                    if (count>0)
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        Queue<Pokemon> deadPokemons = new Queue<Pokemon>();
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health<=0)
                            {
                                deadPokemons.Enqueue(pokemon);
                            }
                        }
                        while (deadPokemons.Count>0)
                        {
                            trainer.Pokemons.Remove(deadPokemons.Dequeue());
                        }
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
        static bool IsTrainerExist(List<Trainer> trainers,string name)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Name==name)
                {
                    return true;
                }
            }
            return false;
        }
        static void AddPokemon(List<Trainer> trainers, string trainerName,Pokemon pokemon)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Name==trainerName)
                {
                    trainer.Pokemons.Add(pokemon);
                }
            }
        }
    }
}
