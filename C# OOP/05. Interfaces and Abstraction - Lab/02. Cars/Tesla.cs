using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} with {Battery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public int Battery { get; set; }
    }
}