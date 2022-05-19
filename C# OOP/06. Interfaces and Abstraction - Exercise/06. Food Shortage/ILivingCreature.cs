namespace PersonInfo
{
    public interface ILivingCreature
    {
        string Name { get; set; }
        string Birthdate { get; set; }
        int Age { get; set; }
    }
}