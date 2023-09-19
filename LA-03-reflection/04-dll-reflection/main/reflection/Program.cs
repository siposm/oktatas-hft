using classes_dll;
using ReflectionPropertyHelper;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace reflection
{

    public class CheckLengthAttribute : Attribute
    {
        public int MinLength { get; set; }
    }
    public class ToStringAttribute : Attribute
    {

    }
    public class X_Student : Student
    {
        public int semesterCount;
        private bool isActive;
    }
    public class Y_Student : Student
    {
        public void Hello(string someParam)
        {
            Console.WriteLine("Hello, I'm [Y] student and the param you gave me: " + someParam);
        }
    }
    public class Z_Student : Student
    {

    }
    public class Student : Person
    {
        [ToString]
        public int StartYear { get; set; }
        [ToString]
        public int Credits { get; set; }
        [ToString]
        public string NeptunID { get; set; }

        [CheckLength(MinLength = 10)]
        public string Email { get; set; }

        public override string ToString()
        {
            return PropertyHelper.GetPropertiesByAttribute<Student>(this, new ToStringAttribute());
        }

        // *** old tostring for example 03
        //public override string ToString()
        //{
        //    string x = "";

        //    foreach (var item in this.GetType().GetProperties().Where(x =>
        //        x.GetCustomAttribute<ToStringAttribute>() != null))
        //    {
        //        x += "   ";
        //        x += item.Name + "\t=> ";
        //        x += item.GetValue(this);
        //        x += "\n";
        //    }

        //    return x;
        //}
    }
    internal class Program
    {
        static Type TypeGetter<T>()
        {
            return typeof(T);
        }

        static string TypeNameGetter<T>()
        {
            return typeof(T).Name;
        }

        static void Main(string[] args)
        {
            // 01
            // create Person class in dll and include it
            #region code

            Person p = new Person()
            {
                Name = "John Doe",
                Dog = new Dog()
                {
                    Name = "Dog Doe"
                }
            };
            Console.WriteLine(p.Dog.Name);

            #endregion

            // 02
            // get type in various ways (typeof, gettype, assembly etc)
            #region code
            Console.WriteLine("\n\n\n");

            Console.WriteLine(TypeGetter<Person>());
            Console.WriteLine(TypeNameGetter<Person>());

            Assembly assem = Assembly.GetExecutingAssembly();
            Type[] types = assem.GetTypes();
            Console.WriteLine("FROM CURRENT");
            foreach (var item in types) Console.WriteLine(item);

            Assembly assem2 = Assembly.LoadFrom(@"../../../../classes-dll.dll");
            Type[] types2 = assem2.GetTypes();
            Console.WriteLine("FROM LOADED DLL");
            foreach (var item in types2) Console.WriteLine(item);

            #endregion

            // 03
            // inherit student from person, add tostring with reflection (to get properties programatically with values)
            #region code

            // see student class's commented tostring method

            #endregion

            // 04
            // create propertyGetter with reflection in separate dll and include it, use it in tostring
            #region code
            Console.WriteLine("\n\n\n");

            Student s = new Student()
            {
                Age = 77,
                Credits = 6,
                Name = "Lajos",
                StartYear = 2023,
                NeptunID = "ASD123",
                Email = "alma@korte.hu"
            };

            Console.WriteLine(s);

            #endregion

            // 05
            // create collection and iterate through. if type is X then call it's method
            #region code
            Console.WriteLine("\n\n\n");

            Student[] students = new Student[10];
            Random r = new Random();
            Func<Type> typeRandomizer = () =>
            {
                int rnd = r.Next(5);
                if (rnd == 0)
                    return typeof(X_Student);
                else if (rnd == 1)
                    return typeof(Y_Student);
                else
                    return typeof(Z_Student);
            };

            for (int i = 0; i < students.Length; i++)
            {
                Student stud = assem.CreateInstance(typeRandomizer().ToString()) as Student;
                stud.Email = "almakorte@loremipsum.hu";
                students[i] = stud;

                Console.WriteLine("TYPE: " + stud.GetType().Name);
                Console.WriteLine(stud);

                if (stud is X_Student)
                {
                    (stud as X_Student).semesterCount = 88888;
                }

                if (stud is Y_Student)
                {
                    MethodInfo mi = stud.GetType().GetMethod("Hello");
                    mi?.Invoke(stud, new object[] { "** hello_world **" });
                }
            }
            #endregion

            // 06
            // create email validation with reflection and attribute
            #region code
            Console.WriteLine("\n\n\n");

            students[0].Email = "a@a.hu";

            foreach (Student studObj in students)
            {
                if (studObj is Student) // weak(er) filtering because it includes the descendant classes as well
                //if (studObj.GetType().Equals(typeof(Student))) // strict(er) filtering, ONLY student class
                {
                    foreach (PropertyInfo prop in studObj.GetType().GetProperties())
                    {
                        foreach (Attribute attr in prop.GetCustomAttributes())
                        {
                            CheckLengthAttribute cla = attr as CheckLengthAttribute;
                            if (prop.Name == "Email")
                            {
                                if (prop.GetValue(studObj).ToString().Length < cla.MinLength)
                                {
                                    Console.WriteLine("*** ERROR, email is not long enough!");
                                }
                            }
                        }
                    }
                }
            }

            #endregion
        }
    }
}