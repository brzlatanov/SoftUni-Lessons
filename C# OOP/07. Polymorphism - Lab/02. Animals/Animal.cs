namespace Animals
{
    public class Animal
    {
        public string name;
        public string favouriteFood;

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my favourite food is {this.favouriteFood}";
        }
    }
}