namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int privateCapacity = 15;
        public BoxingGym(string name) : base(name, 15)
        {
        }
    }
}