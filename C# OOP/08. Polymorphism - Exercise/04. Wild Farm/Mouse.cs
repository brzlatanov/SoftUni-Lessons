using System;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name,weight, livingRegion)
        {
            
        }
        public override void Feed(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += food.Quantity * 0.10;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public void MakeSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}