using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> privateModelsCollection;

        public RacerRepository()
        {
            this.privateModelsCollection = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.privateModelsCollection;
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            privateModelsCollection.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.privateModelsCollection.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer racer = this.privateModelsCollection.FirstOrDefault(r => r.Username == property);
            return racer;
        }
    }
}