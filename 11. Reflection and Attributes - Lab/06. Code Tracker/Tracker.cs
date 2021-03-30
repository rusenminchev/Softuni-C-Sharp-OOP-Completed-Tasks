using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    [Author("Velizar")]
    public class Tracker
    {
        [Author("Atanas")]
        public Dictionary<string, List<string>> PrintMethodsByAuthor()
        {
            var types = Assembly
                .GetExecutingAssembly()              
                .GetTypes();

            var result = new Dictionary<string, List<string>>();

            foreach (var type in types)
            {
                    var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance 
                        | BindingFlags.NonPublic | BindingFlags.Static);
                
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes<AuthorAttribute>();

                    foreach (var attribute in attributes)
                    {
                        var author = attribute.Name;

                        if (!result.ContainsKey(author))
                        {
                            result.Add(author, new List<string>());
     
                        }

                        result[author].Add(method.Name);
                        //Console.WriteLine($"{type.Name} - {method.Name} - {author}");
                    }
                }

            }

            return result;
        }
    }
}
