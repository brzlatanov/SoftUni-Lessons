using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] familyMember = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person currentPerson = new Person(familyMember[0], int.Parse(familyMember[1]));

                Family.AddMember(currentPerson);
            }

            Person oldestPerson = Family.GetOldestMember();

            Console.Write(oldestPerson.Name + " " + oldestPerson.Age);
        }
    }
}
