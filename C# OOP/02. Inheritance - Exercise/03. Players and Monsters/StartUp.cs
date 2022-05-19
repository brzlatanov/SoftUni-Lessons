using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight kralArtur = new BladeKnight("KralArtur", 100);

            Console.WriteLine(kralArtur);
        }
    }
}