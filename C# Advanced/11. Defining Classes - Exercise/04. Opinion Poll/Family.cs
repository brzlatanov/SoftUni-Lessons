using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private static List<Person> familyList = new List<Person>();

        public static void AddMember(Person member)
        {
            familyList.Add(member);
        }

        public static void GetOldestMember()
        {
            Person oldestMember = null;

            int maxAge = int.MinValue;

            for (int i = 0; i < familyList.Count; i++)
            {
                if (familyList[i].Age > maxAge)
                {
                    maxAge = familyList[i].Age;
                    oldestMember = familyList[i];
                }
            }
            familyList = familyList.Where(x => x.Age > 30).OrderBy(x=> x.Name).ToList();

            foreach (var member in familyList)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
