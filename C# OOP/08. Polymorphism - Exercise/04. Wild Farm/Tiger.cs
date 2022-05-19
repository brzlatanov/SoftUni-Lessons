using System;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {

        }
        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 1.00;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}