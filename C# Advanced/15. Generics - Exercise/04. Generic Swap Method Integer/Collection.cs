using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GenericSwapMethod
{
    class Collection<T>
    {
        private List<T> list = new List<T>();

        public void Add(T element)
        {
            list.Add(element);
        }

        public void Swap(int firstElement, int secondElement)
        {
            if (firstElement > 0 || firstElement < list.Count || secondElement > 0 || secondElement < list.Count)
            {
                T temp = list[firstElement];
                list[firstElement] = list[secondElement];
                list[secondElement] = temp;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }

        public void ToString()
        {
            foreach (var item in list)
            {
                Console.Write($"{item.GetType()}: {item}");
                Console.WriteLine();
            }
        }
    }
}
