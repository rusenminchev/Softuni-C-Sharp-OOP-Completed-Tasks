using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigateClass, params string[] privateFields)
        {
            Type classType = Type.GetType(investigateClass);

            var fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.Static);

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {investigateClass}");

            foreach (FieldInfo field in fields.Where(f => privateFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);


            var methods = classType.GetMethods(BindingFlags.Instance
                | BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
