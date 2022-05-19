using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Where(t => t.GetType().IsSubclassOf(typeof(MyValidationAttribute_))).Cast<MyValidationAttribute_>().ToArray();

                foreach (var attribute in attributes)
                {
                    bool isValid = attribute.IsValid(property.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}