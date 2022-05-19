using System.Threading;

namespace PersonInfo
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public string Group { get; set; }
        public int Age { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }

        public int Food { get; set; }
    }
}