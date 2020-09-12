using System;
using System.Linq;
using System.Reflection;

namespace _02_reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    class CheckLength : Attribute
    {
        public int MaxLength { get; set; }
    }

    interface IMyObject 
    {
        // szándékosan üres
    }

    class Person : IMyObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Student : Person
    {
        [CheckLength(MaxLength = 6)]
        public string NeptunID { get; set; }

        public int Credits { get; set; }
    }

    class BscStudent : Student
    {
        public int EnrollmentYear; // sima mező, nem tulajdonság

        private int ActiveSemesters_1;
        private int ActiveSemesters_2;
        private int ActiveSemesters_3;
        private int ActiveSemesters_4;

        public string Greeting()
        {
            return "Hi! I'm "+ Name +", nice to meet you!";
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            # region 01-BASICS-DEMO

            Person p = new Person(){
                Name = "Test Person", ID = 999 
            };

            Type t = typeof(Person); // !!!??? vs .GetType()
            PropertyInfo[] infos = t.GetProperties(); // using reflection

            foreach (var item in infos)
            {
                Console.WriteLine("\t PROP NAME: " + item.Name);
                Console.WriteLine("\t PROP VALUE: " + item.GetValue(p)); // instance kell neki!
            }

            PropertyInfo pi = t.GetProperty("Name"); // + GetMethods , GetFields
            Console.WriteLine(pi);
            Console.WriteLine(pi.GetValue(p));

            // ---------------------------------------------------------------

            // TODO invoke greetings method !!

            #endregion

            
            
            
            // ##############################################################################################################################




            # region 02-EXAMPLE-GENERATE-RANDOM-TYPES

            IMyObject[] students = new IMyObject[10];
            Random r = new Random();

            Func<Type> typeRandomizer = ( () => {

                int x = r.Next(3);

                if(x == 0)
                    return typeof(Student);
                if(x == 1)
                    return typeof(Person);
                else
                    return typeof(BscStudent);

            });

            Assembly assem = Assembly.GetExecutingAssembly();

            for (int i = 0; i < students.Length; i++)
            {
                IMyObject imo = (IMyObject)assem.CreateInstance(typeRandomizer().ToString());
                students[i] = imo;
                System.Console.WriteLine("--> " + imo/*.GetType()*/);
            }

            // annak megfelelően hogy milyen típus listázzuk ki a tulajdonságokat + metódusokat + adattagokat

            foreach (var sObject in students)
            {
                Console.WriteLine("\n\n");

                Console.WriteLine(">> TYPE:" + sObject.GetType());

                Console.WriteLine(">> FIELDS:");
                foreach (var field in sObject.GetType().GetFields())
                    Console.WriteLine("\t" + field.Name);

                Console.WriteLine(">> PROPERTIES:");
                foreach (var prop in sObject.GetType().GetProperties())
                    Console.WriteLine("\t" + prop.Name);

                Console.WriteLine(">> METHODS:");
                foreach (var method in sObject.GetType().GetMethods())
                    Console.WriteLine("\t" + method.Name);
            }


            #endregion
            



            // ##############################################################################################################################




            #region 03-EXAMPLE-WITH-ATTRIBUTES

            // a Student típusok neptunkódját ellenőrizzük le

            int countStudentTypes = 0;
            string initNeptunID = "AAA1234"; // AAA123 >> OK, 6 db karakter mehet

            foreach (var studentObject in students)
            {
                if(studentObject.GetType().Equals(typeof(Student)))
                {
                    countStudentTypes++;

                    foreach (PropertyInfo prop in studentObject.GetType().GetProperties())
                    {
                        foreach (Attribute attr in prop.GetCustomAttributes())
                        {
                            CheckLength cl = attr as CheckLength;
                            if(prop.Name == "NeptunID")
                            {
                                if(initNeptunID.Length <= cl.MaxLength)
                                {
                                    (studentObject as Student).NeptunID = initNeptunID;
                                }
                                else
                                {
                                    (studentObject as Student).NeptunID = initNeptunID.Substring(0,6);
                                    //throw new Exception("ERROR: NEPTUN ID IS INCORRECT!");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n-----------------\n");
            Console.WriteLine("STUDENT TYPES: " + countStudentTypes);
            
            // Kérjük le a Student típusokat és írjuk ki a neptun kódjukat, hogy meggyőződjünk.
            
            var q = from x in students
                    where x.GetType().Equals(typeof(Student))
                    select x;
            
            q.ToList().ForEach( x => Console.WriteLine((x as Student).NeptunID));

            #endregion
        }
    }
}
