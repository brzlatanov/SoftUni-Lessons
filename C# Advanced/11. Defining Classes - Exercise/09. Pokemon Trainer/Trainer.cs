using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;

            BadgesCount = 0;

            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int BadgesCount { get; set; }

       public List<Pokemon> Pokemons { get; set; }

    }
}
