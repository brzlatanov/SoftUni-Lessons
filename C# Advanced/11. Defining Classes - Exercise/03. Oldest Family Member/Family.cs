using System;
using System.Collections.Generic;
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

        public static Person GetOldestMember()
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

            return oldestMember;
        }
    }
}
