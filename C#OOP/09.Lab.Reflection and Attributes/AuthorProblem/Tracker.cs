using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes();
                    foreach (var attr in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {(attr as AuthorAttribute).Name}");
                    }
                }
            }
        }
    }
}
