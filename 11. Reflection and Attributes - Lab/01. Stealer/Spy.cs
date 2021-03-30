using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigateClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigateClass);

            var fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance 
                | BindingFlags.Public | BindingFlags.Static);

            var classInstance = Activator.CreateInstance(classType, new object[] { });
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {investigateClass}");

            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
