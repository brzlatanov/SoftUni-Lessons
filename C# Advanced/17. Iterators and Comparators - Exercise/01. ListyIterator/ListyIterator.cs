using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index = 0;
        public ListyIterator(params T[] parameters)
        {
            list = new List<T>(parameters);
        }

        public bool Move()
        {
            if (index+1 < list.Count)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (index + 1 < list.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }
        }
    }
}
