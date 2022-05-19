using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        // • equipment - EquipmentRepository 
        // • gyms - a collection of IGym
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName); //?? if gym doesn't exist?

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (athleteType == "Boxer" && gym.GetType().Name != "BoxingGym")
            {
                return "The gym is not appropriate.";
            }
            if (athleteType == "Weightlifter" && gym.GetType().Name != "WeightliftingGym")
            {
                return "The gym is not appropriate.";
            }

            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";


        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}