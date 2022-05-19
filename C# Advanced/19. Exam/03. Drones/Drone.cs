using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public string Name
        {
            get; private set;
        }
        public string Brand { get; private set; }
        public int Range { get; private set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.Name}");
            sb.AppendLine($"Manufactured by: {this.Brand}");
            sb.AppendLine($"Range: {this.Range} kilometers");
            return sb.ToString().TrimEnd();
            // "Drone: {name}
            // Manufactured by: { brand}
            // Range: { range}
            // kilometers"
        }
    }
}
