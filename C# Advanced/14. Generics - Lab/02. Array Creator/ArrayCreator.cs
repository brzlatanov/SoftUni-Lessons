using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] returnArr = new T[length];

            for (int i = 0; i < returnArr.Length; i++)
            {
                returnArr[i] = item;
            }

            return returnArr;
        }
    }
}
