using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GenericSwapMethod
{
    public class Box<T> : IComparable<T>
    {

        public static int CompareTo<T>(List<T> list, T item2) where T : IComparable<T>
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(item2) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }


        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }
}
