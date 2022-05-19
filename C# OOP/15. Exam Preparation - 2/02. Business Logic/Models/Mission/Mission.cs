using System;
using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(a=> a.CanBreath))
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    astronaut.Bag.Items.Add(planet.Items.First());
                    planet.Items.Remove(planet.Items.First());
                    astronaut.Breath();
                }
            }
        }
    }
}