using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private List<IAstronaut> astronauts;
        private List<IPlanet> planets;
        private int exploredPlanetsCount;
        public Controller()
        {
            this.astronauts = new List<IAstronaut>();
            this.planets = new List<IPlanet>();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FirstOrDefault(a => a.Name == astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planets.FirstOrDefault(p => p.Name == planetName);

            List<IAstronaut> missionAstronauts = astronauts.Where(a => a.Oxygen > 60).ToList();

            int livesBeforeMission = missionAstronauts.Count;

            if (livesBeforeMission == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission currentMission = new Mission();
            currentMission.Explore(planet, missionAstronauts);
            exploredPlanetsCount++;
            missionAstronauts.RemoveAll(a => a.Oxygen <= 0);
            int livesAfterMission = missionAstronauts.Count;

            return string.Format(OutputMessages.PlanetExplored, planetName, (livesBeforeMission - livesAfterMission));


        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronauts)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}