using System.Reflection;

namespace ReflectionPropertyHelper
{
    public static class PropertyHelper
    {
        public static string GetPropertiesByAttribute<T>(T type, Attribute attribute)
        {
            string x = "";

            foreach (var item in type.GetType().GetProperties()
                .Where(x => x.GetCustomAttribute(attribute.GetType()) != null)
            )
            {
                x += "\t";
                x += item.Name + "\t=> ";
                x += item.GetValue(type);
                x += "\n";
            }

            return x;
        }
    }
}