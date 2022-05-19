using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Farm
{
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("barking...");
        }
    }
}
