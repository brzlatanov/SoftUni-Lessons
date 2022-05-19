namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double privateWeight = 10000;
        private const decimal privatePrice = 80;
        public Kettlebell() : base(privateWeight, privatePrice)
        {
        }
    }
}