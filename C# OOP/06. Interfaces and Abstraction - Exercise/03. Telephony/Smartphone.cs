using System;

namespace Phones
{
    public class Smartphone : ISmartPhoneCall
    {
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }
    }
}