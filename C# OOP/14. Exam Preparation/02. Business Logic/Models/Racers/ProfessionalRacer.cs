using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car) : base(username, "strict", 30, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 10;
        }
    }
}