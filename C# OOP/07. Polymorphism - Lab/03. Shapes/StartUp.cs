using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Circle(13);
            Console.WriteLine(shape.Draw());
        }
    }
}
