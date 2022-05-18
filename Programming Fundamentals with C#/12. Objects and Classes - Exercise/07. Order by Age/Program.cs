using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            List<Human> personList = new List<Human>();

            while (input[0] != "End")
            {
                string name = input[0];
                string identity = input[1];
                int age = int.Parse(input[2]);
                Human person = new Human(name, identity, age);
                personList.Add(person);
                input = Console.ReadLine().Split(" ");
            }

            personList = personList.OrderBy(o => o.Age).ToList();

            foreach (var person in personList)
            {
                Console.WriteLine(string.Join("\n", person.ToString()));
            }
        }
        public class Human
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
            public Human(string name, string identity, int age)
            {
                Name = name;
                ID = identity;
                Age = age;
            }
            public static List<Human> humans { get; set; }
            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }
    }
}
