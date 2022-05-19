using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStackExercise
{
    public class Stack<T> : IEnumerable<int>
    {
        private List<int> stackList = new List<int>();

        private int index = -1;

        public void Push(int element)
        {
            stackList.Add(element);
            index++;
        }

        public int Pop()
        {
            if (stackList.Count > 0)
            {
                int element = stackList[index];
                stackList.Remove(element);
                index--;
                return element;
            }
            else
            {
                Console.WriteLine("No elements");
                return 0;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = stackList.Count - 1; i >= 0; i--)
            {
                yield return stackList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
