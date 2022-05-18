using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int pokepowerNOriginal = pokePowerN;
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());
            int subtraction = 0;
            int targetPoked = 0;

            while (true)
            {
                pokePowerN -= distanceM;
                targetPoked++;
                if (pokePowerN * 2 == pokepowerNOriginal && exhaustionFactorY > 0)
                {
                    pokePowerN /= exhaustionFactorY;
                }
                if (pokePowerN < distanceM)
                {
                    break;
                }
            }

            Console.WriteLine(pokePowerN);
            Console.WriteLine(targetPoked);
        }
    }
}
