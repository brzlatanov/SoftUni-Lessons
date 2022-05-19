using System;
using System.Collections.Generic;
using System.Text;

namespace TupleExercise
{
    public class CustomTuple<T, U>
    {
        private T itemOne { get; }
        private U itemTwo { get; }

        public CustomTuple(T inputOne, U inputTwo)
        {
            itemOne = inputOne;
            itemTwo = inputTwo;
        }

        public override string ToString()
        {
            return ($"{itemOne} -> {itemTwo}");
        }
    }
}
