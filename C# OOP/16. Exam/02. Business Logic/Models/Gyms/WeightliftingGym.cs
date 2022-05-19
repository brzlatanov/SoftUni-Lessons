namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int privateCapacity = 20;
        public WeightliftingGym(string name) : base(name, privateCapacity)
        {
        }
    }
}