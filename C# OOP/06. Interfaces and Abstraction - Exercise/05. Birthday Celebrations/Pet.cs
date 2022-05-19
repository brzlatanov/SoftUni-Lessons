namespace PersonInfo
{
    public class Pet : ILivingCreature
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public int Age { get; set; }
    }
}