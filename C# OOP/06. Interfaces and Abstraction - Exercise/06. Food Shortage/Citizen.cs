namespace PersonInfo
{
    public class Citizen : IIdentifiable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Id { get; set; }

        public string Birthdate { get; set; }
        public int Age { get; set; }


        public void BuyFood()
        {
            this.Food += 10;
        }

        public int Food { get; set; }
    }
}