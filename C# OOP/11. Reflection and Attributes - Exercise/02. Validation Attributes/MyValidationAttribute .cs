using System;

namespace ValidationAttributes
{
    public abstract class MyValidationAttribute_: Attribute
    {
        public abstract bool IsValid(object obj);
    }
}