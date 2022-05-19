namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute_
    {
        public override bool IsValid(object obj) => obj != null;
    }
}