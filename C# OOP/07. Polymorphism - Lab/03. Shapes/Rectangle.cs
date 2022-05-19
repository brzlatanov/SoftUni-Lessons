using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }
        public override double CalculatePerimeter() // perimeter = 2 * (length + width);
        {
            return 2 * this.Width + 2 * this.Height;
        }

        public override double CalculateArea() // l * w
        {
            return this.Width * this.Height;
        }

        public override string Draw()
        {

            return base.Draw() + this.GetType().Name;

        }
    }
}