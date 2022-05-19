using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            var classType = Type.GetType(investigatedClass);
            var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic |
                                                  BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            var classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f=> requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var classType = Type.GetType("Stealer." + className);
            var classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            var classMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in classMethods)
            {
                if (method.IsPrivate && method.Name.ToUpper().Contains("GET"))
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }
                else if (method.IsPublic && method.Name.ToUpper().Contains("SET"))
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }
            }

            return sb.ToString().Trim();
        }
    }
}