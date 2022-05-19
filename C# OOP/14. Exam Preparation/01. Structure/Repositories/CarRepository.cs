using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> privateModelsCollection;
        public CarRepository()
        {
            privateModelsCollection = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => this.privateModelsCollection;
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            privateModelsCollection.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.privateModelsCollection.Remove(model);
        }

        public ICar FindBy(string property)
        {
            ICar car = this.privateModelsCollection.FirstOrDefault(c => c.VIN == property);
            return car;
        }
    }
}