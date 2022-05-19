using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> internalAstronautList;
        public IReadOnlyCollection<IAstronaut> Models { get; } 

        public AstronautRepository()
        {
            this.internalAstronautList = new List<IAstronaut>();
            this.Models = new ReadOnlyCollection<IAstronaut>(internalAstronautList);
        }
        public void Add(IAstronaut astronaut)
        {
            this.internalAstronautList.Add(astronaut);
        }

        public bool Remove(IAstronaut model)
        {
            IAstronaut astronaut = this.internalAstronautList.FirstOrDefault(a => a.Equals(model));
            if (astronaut == null)
            {
                return false;
            }

            this.internalAstronautList.Remove(astronaut);
            return true;
        }

        public IAstronaut FindByName(string name)
        {
            return this.internalAstronautList.FirstOrDefault(a => a.Name == name);
        }
    }
}