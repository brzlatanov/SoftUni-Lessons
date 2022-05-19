namespace Gym.Models.Equipment
{
    public class BoxingGloves :Equipment
    {
        private const double privateWeight = 227;
        private const decimal privatePrice = 120;
        public BoxingGloves() : base(privateWeight, privatePrice)
        {
        }
    }
}