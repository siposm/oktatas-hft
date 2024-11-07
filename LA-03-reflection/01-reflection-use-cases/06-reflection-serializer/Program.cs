using System.Reflection;
using System.Text;

namespace _06_reflection_serializer
{
    public class Developer
    {
        public int YearsOfExperience { get; set; }
        public string Name { get; set; }
    }

    public static class ReflectiveSerializer
    {
        public static string Serialize(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            Type type = obj.GetType();
            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object value = property.GetValue(obj);
                sb.AppendLine($"{property.Name}:{value}");
            }

            return sb.ToString();
        }

        public static T Deserialize<T>(string serializedData) where T : new()
        {
            if (string.IsNullOrEmpty(serializedData)) throw new ArgumentNullException(nameof(serializedData));

            T obj = new T();
            Type type = typeof(T);

            string[] lines = serializedData.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string propertyName = parts[0];
                    string value = parts[1];

                    PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                    if (property != null && property.CanWrite)
                    {
                        object convertedValue = Convert.ChangeType(value, property.PropertyType);
                        property.SetValue(obj, convertedValue);
                    }
                }
            }

            return obj;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Developer original = new Developer { YearsOfExperience = 1, Name = "John Doe" };
            string serialized = ReflectiveSerializer.Serialize(original);
            Console.WriteLine("Serialized data:");
            Console.WriteLine(serialized);

            Developer deserialized = ReflectiveSerializer.Deserialize<Developer>(serialized);
            Console.WriteLine($"Deserialized object: Id = {deserialized.YearsOfExperience}, Name = {deserialized.Name}");
        }
    }
}
