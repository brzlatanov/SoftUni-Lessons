using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class List
    {
        private const int DefaultCapacity = 2;
        private int[] items;

        public int this[int i] // defines an indexer
        {
            get
            {
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[i];
            }

            set
            {
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                items[i] = value;
            }
        }

        public List()
        {
            items = new int[DefaultCapacity];
        }

        public int Count { get; private set; }
        public void Add(int element)
        {
            if (Count == items.Length)
            {
                int[] tempArray = new int[items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    tempArray[i] = items[i];
                }

                items = tempArray; //this also changes the size of items to be the same as tempArray's
            }
            items[Count++] = element;
            
        }

        public int RemoveAt(int index)
        {
            if (index > Count -1 || index < 0)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            int element = items[index];

            items[index] = 0;

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;

            if (Count <= items.Length /4)
            {
                int[] tempArray = new int[items.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArray[i] = items[i];
                }

                items = tempArray;
            }

            return element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Count || secondIndex < 0 || secondIndex >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            int tempElement = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = tempElement;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", items));
        }
    }
}
