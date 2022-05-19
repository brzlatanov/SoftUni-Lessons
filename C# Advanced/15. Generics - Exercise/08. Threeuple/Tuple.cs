using System;
using System.Collections.Generic;
using System.Text;

namespace TupleExercise
{
    public class CustomTuple<T, U, V>
    {
        private T itemOne { get; }
        private U itemTwo { get; }
        private V itemThree { get;  }

        public CustomTuple(T inputOne, U inputTwo, V inputThree)
        {
            itemOne = inputOne;
            itemTwo = inputTwo;
            itemThree = inputThree;
        }

        public override string ToString()
        {
            return ($"{itemOne} -> {itemTwo} -> {itemThree}");
        }
    }
}
