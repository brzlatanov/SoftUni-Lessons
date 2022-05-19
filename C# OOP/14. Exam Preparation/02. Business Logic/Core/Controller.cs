using System;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType); // throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            this.racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            Map currentMap = new Map();

            string result = currentMap.StartRace(racerOne, racerTwo);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(r=> r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
                // "{racer type}: {racer username}"
                // "--Driving behavior: {racingBehavior}"
                // "--Driving experience: {drivingExperience}"
                // "--Car: {carMake} {carModel} ({carVIN})"
            }

            return sb.ToString().TrimEnd();
        }
    }
}