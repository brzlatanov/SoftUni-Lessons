namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; set; }

        public Feline(string name, double weight, string region, string breed)
        {
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = region;
            this.Breed = breed;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        public override void Feed(Food food)
        {
            
        }
    }
}