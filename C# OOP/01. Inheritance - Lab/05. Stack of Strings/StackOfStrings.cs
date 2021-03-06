using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> inputStack)
        {
            while (inputStack.Any())
            {
                this.Push(inputStack.Pop());
            }
        }
    }
}
