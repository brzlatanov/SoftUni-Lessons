using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Person> personList = new List<Person>();

            while (command[0] != "END")
            {
                string name = command[0];
                int age = int.Parse(command[1]);
                string town = command[2];

                Person currentPerson = new Person(name, age, town);

                personList.Add(currentPerson);

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int n = int.Parse(Console.ReadLine());

            int equalPeople = 0;
            int notEqualPeople = 0;
            

            for (int i = 0; i < personList.Count; i++)
            {
                if (personList[i].CompareTo(personList[n - 1]) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {equalPeople + notEqualPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
