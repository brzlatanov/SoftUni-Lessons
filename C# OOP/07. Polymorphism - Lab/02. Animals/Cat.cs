namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public override string ExplainSelf()
        {
            return $"I am {this.name} and my favourite food is {this.favouriteFood} MEEOW";
        }
    }
}