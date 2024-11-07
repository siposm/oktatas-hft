using System.Reflection;

namespace _03_reflection_random_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IMyObject> students = new List<IMyObject>();
            Random r = new Random();

            Func<Type> typeRandomizer = () =>
                {
                    int x = r.Next(3);

                    if (x == 0)
                        return typeof(Student);
                    if (x == 1)
                        return typeof(Person);
                    else
                        return typeof(BScStudent);
                };

            Assembly assem = Assembly.GetExecutingAssembly();

            for (int i = 0; i < 5; i++)
            {
                IMyObject imo = (IMyObject)assem.CreateInstance(typeRandomizer().ToString())!;
                students.Add(imo);
                Console.WriteLine("--> " + imo /*.GetType()*/);
            }

            // based on what is the type, list the properties + methods + fields

            foreach (var sObject in students)
            {
                Console.WriteLine("\n\n  ------------------------\n\n");

                Console.WriteLine(">> TYPE: " + sObject.GetType().Name);

                Console.WriteLine("\n>> FIELDS:");
                foreach (var field in sObject.GetType().GetFields())
                    Console.WriteLine("\t" + field.Name);

                Console.WriteLine("\n>> PROPERTIES:");
                foreach (var prop in sObject.GetType().GetProperties())
                    Console.WriteLine("\t" + prop.Name);

                Console.WriteLine("\n>> METHODS:");
                foreach (var method in sObject.GetType().GetMethods())
                    Console.WriteLine("\t" + method.Name);
            }
        }
    }
}
