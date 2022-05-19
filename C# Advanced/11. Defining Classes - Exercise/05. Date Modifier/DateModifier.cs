using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static void DateDifference(string date1, string date2)
        {
            DateTime date1Formatted = Convert.ToDateTime(date1);
            DateTime date2Formatted = Convert.ToDateTime(date2);
            string[] dateDifference = date1Formatted.Subtract(date2Formatted).ToString().Split(".");
            

            Console.WriteLine(Math.Abs(int.Parse(dateDifference[0])));
        }
    }
}
