using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings testStack = new StackOfStrings();

            Console.WriteLine(testStack.IsEmpty());

            testStack.Push("asd");

            Console.WriteLine(testStack.IsEmpty());

            Stack<string> inputStack = new Stack<string>();

            inputStack.Push("1");
            inputStack.Push("2");
            inputStack.Push("3");

            testStack.AddRange(inputStack);
        }
    }
}
