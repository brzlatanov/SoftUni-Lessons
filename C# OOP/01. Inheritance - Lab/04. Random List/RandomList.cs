using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private List<string> RandomListInstance = new List<string>();
        public string RandomString()
        {
            Random rnd = new Random();

            int r = rnd.Next(RandomListInstance.Count);

            string elementToRemove = RandomListInstance[r];

            RandomListInstance.Remove(RandomListInstance[r]);

            return elementToRemove;
        }

        public void Add(string input)
        {
            RandomListInstance.Add(input);
        }
    }
}
