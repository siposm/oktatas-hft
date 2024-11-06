using System.Reflection;
using System;

namespace _02_reflection_basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { Name = "Test Person", ID = 999 };

            Type t = typeof(Person); // vs .GetType()
            PropertyInfo[] infos = t.GetProperties(); // using reflection

            foreach (var item in infos)
            {
                Console.WriteLine("\t PROP NAME: " + item.Name);
                Console.WriteLine("\t PROP VALUE: " + item.GetValue(person)); // instance MUST be provided! 'person'
            }

            PropertyInfo propInfo = t.GetProperty("Name")!; // + GetMethods , GetFields
            Console.WriteLine(propInfo);
            Console.WriteLine(propInfo.GetValue(person));

            // Creating type dynamically
            Type bscStudType = typeof(BScStudent);
            // v1
            object testInstance_1 = Activator.CreateInstance(bscStudType);
            // v2
            object testInstance = CreateType(bscStudType);

            // Calling the method dynamically
            // v1
            MethodInfo toInvoke = bscStudType.GetMethod("Greeting")!;
            var returnedValue = toInvoke.Invoke(testInstance, null);
            Console.WriteLine("Invoked method's returned value: " + returnedValue);
            // v2
            returnedValue = CallMethod(bscStudType, "Greeting", testInstance);
            Console.WriteLine("Invoked method's returned value: " + returnedValue);
        }

        static object CreateType(Type type)
        {
            return Activator.CreateInstance(type)!;
            // On this level we DON'T KNOW the type --> can't write "return new type()"
        }

        static string CallMethod(Type type, string methodName, object instance)
        {
            return type.GetMethod(methodName)?.Invoke(instance, null)?.ToString()!;
        }
    }
}
