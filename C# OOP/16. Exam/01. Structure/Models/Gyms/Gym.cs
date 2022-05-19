using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym :IGym
    {
        private string name;
        private List<IEquipment> privateEquipmentList;
        private List<IAthlete> privateAthleteList;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.privateAthleteList = new List<IAthlete>();
            this.privateEquipmentList = new List<IEquipment>();
        }
        public string Name
        {
            get 
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
                //If the name is null or empty, throw an ArgumentException with a message: "Gym name cannot be null or empty."
            }
        }
        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get
            {
                double finalWeight = 0;
                foreach (var equipment in this.privateEquipmentList)
                {
                    finalWeight += equipment.Weight;
                }

                return finalWeight;
            }
        }

        public ICollection<IEquipment> Equipment => this.privateEquipmentList;
        public ICollection<IAthlete> Athletes => this.privateAthleteList;
        public void AddAthlete(IAthlete athlete)
        {
            if (this.privateAthleteList.Count < this.Capacity)
            {
                this.privateAthleteList.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
                //Adds an athlete in the gym if there is space left for him / her, otherwise throw an InvalidOperationException with a message "Not enough space in the gym."
            }
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.privateAthleteList.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.privateEquipmentList.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.privateAthleteList)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine("Athletes: ");
            if (this.privateAthleteList.Any())
            {
                sb.Append(string.Join(", ", this.privateAthleteList.ToString())); // ??
            }
            else
            {
                sb.Append("No athletes");
            }

            sb.AppendLine($"Equipment total count: {this.privateEquipmentList.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight} grams");

            return sb.ToString().TrimEnd();
            // "{gymName} is a {gymType}:
            // Athletes: { athleteName1}, { athleteName2}, { athleteName3} (…) / No athletes
            // Equipment total count: { equipmentCount}
            // Equipment total weight: { equipmentWeight}
            // grams"
        }
    }
}