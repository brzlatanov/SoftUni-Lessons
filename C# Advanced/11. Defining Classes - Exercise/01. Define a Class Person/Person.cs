using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DefiningClasses
{
    class Person
    {
        private string name { get; set; }
        private int age { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {

            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

    }
}
