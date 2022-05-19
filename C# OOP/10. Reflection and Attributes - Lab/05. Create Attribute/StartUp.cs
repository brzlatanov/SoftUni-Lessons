using System;
using System.Runtime.InteropServices.ComTypes;

namespace AuthorProblem
{
    public class StartUp
    {
        [Author("ExampleAttribute")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
