namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }


        public Citizen (string name, int age, string id)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
    }
}