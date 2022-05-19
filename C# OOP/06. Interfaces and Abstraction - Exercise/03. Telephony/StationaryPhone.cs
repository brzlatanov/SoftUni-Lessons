using System;

namespace Phones
{
    public class StationaryPhone :IStationaryPhoneDial
    {
        public void Dial(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}