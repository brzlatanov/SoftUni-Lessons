using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name;
        public int Age;
        public string Town;

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }
        public int CompareTo(Person other)
        {
            if (this.Age == other.Age && this.Name == other.Name && this.Town == other.Town)
            {
                return 0;
            }
            else 
            {
                return 1;
            }
            
        }
    }
}
