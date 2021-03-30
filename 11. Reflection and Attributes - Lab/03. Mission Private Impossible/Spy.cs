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

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            var nonPublicMethods = classType.GetMethods(BindingFlags.Instance
                | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.GetType().BaseType.Name}");
  
            foreach (var nonPublicMethod in nonPublicMethods)
            {
                sb.AppendLine($"{nonPublicMethod.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
