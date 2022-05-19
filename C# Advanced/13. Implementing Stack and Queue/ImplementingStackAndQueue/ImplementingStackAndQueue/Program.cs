using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            List test = new List();
            test.Add(3);
            test.Add(4);

            test.RemoveAt(5);
        }
    }
}
