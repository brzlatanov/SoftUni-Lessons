using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants = new List<Car>();

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            Laps = laps;
            MaxHorsePower = maxHorsePower;
        }

        public int Count => Participants.Count;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            if (Participants.FirstOrDefault(p=> p.LicensePlate == car.LicensePlate) == null && Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.RemoveAll(p => p.LicensePlate == licensePlate) > 0)
            {
                return true;
            }

            return false;

        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.Where(p => p.LicensePlate == licensePlate).FirstOrDefault();
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(p => p.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
           sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
           foreach (var car in Participants)
           {
               sb.AppendLine(car.ToString().TrimEnd());
           }
          // return sb.ToString().TrimEnd('\r', '\n');
            return sb.ToString().TrimEnd('\r', '\n');


        }
    }
}
