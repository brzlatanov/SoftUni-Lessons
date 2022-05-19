using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.dronesList = new List<Drone>();
        }

        private List<Drone> dronesList;
        public IReadOnlyCollection<Drone> Drones => this.dronesList;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public double LandingStrip { get; private set; }
        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(drone.Name) || string.IsNullOrWhiteSpace(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if(this.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                this.dronesList.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
           
        }

        public bool RemoveDrone(string name)
        {
            return this.dronesList.Remove(this.Drones.FirstOrDefault(d => d.Name == name));
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.dronesList.RemoveAll(d=> d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = this.Drones.Where(d => d.Range >= range).ToList();
            foreach (var drone in drones)
            {
                drone.Available = false;
            }

            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in this.Drones.Where(d=> d.Available == true))
            {
                sb.AppendLine(drone.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
