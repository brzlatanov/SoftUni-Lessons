using System;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string result = null;

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo, racerOne);
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne, racerTwo);
            }
            else if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();
                double racerOneMultiplier = 0;
               
                if (racerOne.RacingBehavior == "aggressive")
                {
                    racerOneMultiplier = 1.1;
                }
                else if (racerOne.RacingBehavior == "strict")
                {
                    racerOneMultiplier = 1.2;
                }

                double racerTwoMultiplier = 0;

                if (racerTwo.RacingBehavior == "aggressive")
                {
                    racerTwoMultiplier = 1.1;
                }
                else if (racerTwo.RacingBehavior == "strict")
                {
                    racerTwoMultiplier = 1.2;
                }

                double racerOneResult = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;

                double racerTwoResult = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;

                if (racerOneResult > racerTwoResult)
                {
                    result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                        racerOne.Username);
                }
                else if (racerOneResult < racerTwoResult)
                {
                    result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                        racerTwo.Username);
                }
            }

            return result;
        }
    }
}