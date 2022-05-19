using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Length cannot be zero or negative.");
                    }
                    else
                    {
                        this.length = value;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Length cannot be zero or negative.");
                }

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
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Width cannot be zero or negative.");
                    }
                    else
                    {
                        this.width = value;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Width cannot be zero or negative.");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Height cannot be zero or negative.");
                    }
                    else
                    {
                        this.height = value;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Height cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea() // 2lw + 2lh + 2wh
        {
            return 2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);
        }

        public double LateralSurfaceArea() // 2lh + 2wh
        {
            return 2 * (this.length * this.height) + 2 * (this.width * this.height);
        }

        public double Volume() //lwh
        {
            return this.length * this.width * this.height;
        }
    }
}
