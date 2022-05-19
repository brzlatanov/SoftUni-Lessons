namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }

        public Mammal()
        {

        }
        public Mammal(string name, double weight, string livingRegion)
        {
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
        }
    }
}