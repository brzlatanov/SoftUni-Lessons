namespace PersonInfo
{
    public class Citizen : ILivingCreature, IIdentifiable
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
        

    }
}