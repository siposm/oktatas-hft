using System.Reflection;

namespace _05_reflection_cloner
{
    public class Developer
    {
        public int YearsOfExperience { get; set; }
        public string Name { get; set; }
    }

    public static class ReflectionCloner
    {
        public static T Clone<T>(T source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            Type type = typeof(T);
            T clone = (T)Activator.CreateInstance(type)!;

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source)!;
                    property.SetValue(clone, value);
                }
            }

            return clone;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Developer original = new Developer { YearsOfExperience = 12, Name = "John Doe" };
            Developer copy = ReflectionCloner.Clone(original);

            Console.WriteLine($"Original: {original.YearsOfExperience}, {original.Name}");
            Console.WriteLine($"Copy: {copy.YearsOfExperience}, {copy.Name}");
        }
    }
}
