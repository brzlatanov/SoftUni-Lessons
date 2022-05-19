using System.Reflection.Metadata;

namespace WildFarm
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public Animal()
        {

        }

        public abstract void Feed(Food food);

    }
}