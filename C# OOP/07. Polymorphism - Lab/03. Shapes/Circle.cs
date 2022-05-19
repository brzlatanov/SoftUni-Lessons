using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius {
            get
            {
                return this.radius;
            }
            private set
            {
                this.radius = value;
            }
        }
        public override double CalculatePerimeter() // 2 * pi * r
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalculateArea() // pi * r * r
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}