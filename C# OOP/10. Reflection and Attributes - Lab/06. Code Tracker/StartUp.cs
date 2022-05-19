using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace AuthorProblem
{
    [Author("Ivan")]
    class StartUp
    {
        [Author("George")] 
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n=> n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine("{0} is written by {1}", method.Name, attr.Name);
                    }
                } 
            }
        }
    }
}
