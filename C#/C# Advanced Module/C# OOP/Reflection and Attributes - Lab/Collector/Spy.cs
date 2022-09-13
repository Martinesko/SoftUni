using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    internal class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] reqestedFields)
        {

            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {investigatedClass}");
            foreach (FieldInfo field in classFields.Where(x => reqestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }


            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string investigatorClass)
        {
            Type classType = Type.GetType(investigatorClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public); ;
            MethodInfo[] classPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var field in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{field.Name} have to be public!");
            }
            foreach (var field in classPublicMethod.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{field.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in classNonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string investigatorClass)
        {
            Type classType = Type.GetType(investigatorClass);
            MethodInfo[] classFields = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (var field in classFields.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{field.Name} will return {field.ReturnType}");
            }
            foreach (var field in classFields.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{field.Name} will set field of {field.GetParameters().First().ParameterType}");
            }



            return sb.ToString().Trim();
        }
    }
}
