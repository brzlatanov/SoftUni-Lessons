using System.Collections.Generic;
using System.Linq;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> privateEquipmentList;

        public EquipmentRepository()
        {
            this.privateEquipmentList = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => this.privateEquipmentList;
        public void Add(IEquipment model)
        {
            this.privateEquipmentList.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.privateEquipmentList.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.privateEquipmentList.FirstOrDefault(e => e.GetType().Name == type);
        }
    }
}