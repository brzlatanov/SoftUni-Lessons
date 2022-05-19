namespace PersonInfo
{
    public class Robot : IRobot, IIdentifiable
    {
        public string Model { get; set; }
        public string Id { get; set; }
    }
}