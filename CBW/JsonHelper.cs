using System;
using System.Reflection;
using System.Xml;

namespace CBW
{
    public static class JsonHelper
    {
        private static readonly Assembly jsonAssembly;

        static JsonHelper()
        {
            byte[] jsonAssemblyBytes = Properties.Resources.Newtonsoft_Json;
            jsonAssembly = Assembly.Load(jsonAssemblyBytes);
        }

        public static dynamic DeserializeObject(string json)
        {
            Type type = jsonAssembly.GetType("Newtonsoft.Json.JsonConvert");
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                if (method.Name == "DeserializeObject")
                {
                    if (method.GetParameters().Length == 1)
                    {
                        if (method.GetParameters()[0].ParameterType == typeof(string))
                        {
                            return method.Invoke(null, new object[] { json });
                        }
                    }
                }
            }

            throw new InvalidOperationException("Unable to read configuration file");
        }

        public static string SerializeObject(object value)
        {
            Type type = jsonAssembly.GetType("Newtonsoft.Json.JsonConvert");
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                if (method.Name == "SerializeObject")
                {
                    if (method.GetParameters().Length == 1)
                    {
                        if (method.GetParameters()[0].ParameterType == typeof(object))
                        {
                            return (string)method.Invoke(null, new object[] { value });
                        }
                    }
                }
            }

            throw new InvalidOperationException("Unable to write configuration file.");
        }

        public static string SerializeObject(object value, Formatting formatting)
        {
            Type type = jsonAssembly.GetType("Newtonsoft.Json.JsonConvert");
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                if(method.Name == "SerializeObject")
                {
                    if (method.GetParameters().Length == 2)
                    {
                        if (method.GetParameters()[0].ParameterType == typeof(object))
                        {
                            if (method.GetParameters()[1].ParameterType.FullName == "Newtonsoft.Json.Formatting")
                            {
                                return (string)method.Invoke(null, new object[] { value, formatting });
                            }
                        }
                    }
                }
            }

            throw new InvalidOperationException("Unable to write configuration file.");
        }
    }
}
