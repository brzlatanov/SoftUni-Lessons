using System;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }

        public Bird(string name, double weight, double wingSize)
        {
            this.Name = name;
            this.Weight = weight;
            this.WingSize = wingSize;
        }
        
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}