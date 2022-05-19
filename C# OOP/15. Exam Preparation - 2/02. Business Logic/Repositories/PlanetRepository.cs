using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> internalPlanetList;
        public IReadOnlyCollection<IPlanet> Models { get; }

        public PlanetRepository()
        {
            this.internalPlanetList = new List<IPlanet>();
            this.Models = new ReadOnlyCollection<IPlanet>(internalPlanetList);
        }
        public void Add(IPlanet model)
        {
           this.internalPlanetList.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            IPlanet planet = this.internalPlanetList.FirstOrDefault(p => p.Equals(model));

            if (planet == null)
            {
                return false;
            }

            this.internalPlanetList.Remove(planet);
            return true;
        }

        public IPlanet FindByName(string name)
        {
            return this.internalPlanetList.First(p => p.Name == name);
        }
    }
}