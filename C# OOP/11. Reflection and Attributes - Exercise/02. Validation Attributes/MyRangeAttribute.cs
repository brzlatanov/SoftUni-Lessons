namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute_
    {
        private int maxValue;
        private int minValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            
        }

        public override bool IsValid(object obj)
        {
            int inputInteger = (int)obj;

            if (inputInteger < minValue || inputInteger > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}