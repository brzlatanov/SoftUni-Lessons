using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList asd = new RandomList();

            asd.Add("potato");
            asd.Add("tomato");
            asd.Add("carrot");
            asd.Add("broccoli");

            Console.WriteLine(asd.RandomString());
        }
    }
}
