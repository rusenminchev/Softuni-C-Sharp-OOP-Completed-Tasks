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

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            var publicFields = classType.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.Static);

            var publicMethods = classType.GetMethods(BindingFlags.Instance
                | BindingFlags.Public);

            var nonPublicMethods = classType.GetMethods(BindingFlags.Instance
                | BindingFlags.NonPublic);

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            foreach (var field in publicFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var nonPublicMethod in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethod.Name} must be public!");
            }

            foreach (var publicMethod in publicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} must be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
