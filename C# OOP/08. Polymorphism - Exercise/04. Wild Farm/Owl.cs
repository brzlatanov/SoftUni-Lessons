using System;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }
        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}