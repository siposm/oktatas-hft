using System;
using System.Linq;
using System.Reflection;

namespace _02_reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    class CheckLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
    }

    interface IMyObject 
    {
        // it is empty for a reason
    }

    class Person : IMyObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Student : Person
    {
        [CheckLength(MaxLength = 10)]
        public string Email { get; set; }

        public string NeptunID { get; set; }

        public int Credits { get; set; }
    }

    class BscStudent : Student
    {
        public int EnrollmentYear; // field, not property

        private int ActiveSemesters_1; // private is not visible
        public int ActiveSemesters_2;
        public int ActiveSemesters_3;
        public int ActiveSemesters_4;

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
                Console.WriteLine("\t PROP VALUE: " + item.GetValue( p )); // instance must be provided! 'p'
            }

            PropertyInfo pi = t.GetProperty("Name"); // + GetMethods , GetFields
            Console.WriteLine(pi);
            Console.WriteLine(pi.GetValue(p));

            // ---------------------------------------------------------------

            // Calling the method dynamically
            
            Type bscStudType = typeof(BscStudent);
            object testInstance = Activator.CreateInstance(bscStudType);
            
            MethodInfo toInvoke = bscStudType.GetMethod("Greeting");
            var returnedValue = (string)toInvoke.Invoke(testInstance, null);
            System.Console.WriteLine("Invoked methods return value: " + returnedValue);
            

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
            // based on what is the type, list the properties + methods + fields

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

            // 0. RÉSZ
            // Hozzuk létre a szükséges attribútumot.
            // - CheckLength: int MaxLength tulajdonsággal állítható
            // Alkalmazzuk ezt az Email tulajdonságra Student-ben.
            // 
            // Create the needed attribute.
            // - CheckLength: int MaxLength property can be set
            // Apply this to the Email prop at Student class.

            // 1. RÉSZ
            // A Student típusok emailjeit ellenőrizzük le! (pl. a user beír valamit, és még mielőtt elmentenénk)
            // Reflexió segítségével vizsgáljuk meg a teljes tömböt, HA Student típusról van szó
            // akkor szűrjünk a megfelelő tulajdonságra és attribútum felhasználásával ellenőrizzük
            // annak helyességét.
            //
            // Check the emails of the Student types with reflection. Check the full array, and if one item is Student type
            // then filter for the given property, and check if it's valid or not with the attribute applied to the property.

            int countStudentTypes = 0;
            string newEmail = "lorem-ipsum-dolor-sit-amet@mail.com"; // first section (before @) can be max 10 chars

            foreach (var studentObject in students)
            {
                //if(studentObject is Student) // not good, too weak filtering because it inclides the descendant classes as well
                if(studentObject.GetType().Equals(typeof(Student)))
                {
                    countStudentTypes++;

                    foreach (PropertyInfo prop in studentObject.GetType().GetProperties())
                    {
                        foreach (Attribute attr in prop.GetCustomAttributes())
                        {
                            CheckLengthAttribute cl = attr as CheckLengthAttribute;
                            if(prop.Name == "Email")
                            {
                                string firstPart = newEmail.Split('@')[0];
                                string secondPart = newEmail.Split('@')[1];
                                    
                                if(firstPart.Length <= cl.MaxLength) // email ok
                                { 
                                    (studentObject as Student).Email = newEmail;
                                }
                                else // email not ok
                                {   
                                    (studentObject as Student).Email = firstPart.Substring(0,cl.MaxLength) + "@" + secondPart;
                                    //throw new Exception("ERROR: EMAIL IS INCORRECT!");
                                }
                            }
                        }
                    }
                }
            }

            // HF.: nem csak karakterszámra nézzük az emailt, hanem pl. van-e benne @ jel.
            // Ehhez itt található egy nagyon jó ValidationFactory példa. Érdemes átnézni és logikailag végigkövetni.
            // Ha 2 vagy több attribútum alapján akarunk validálni, akkor ez a helyes irány!
            // link: https://github.com/siposm/oktatas-hft-20211/blob/master/_archived/LA-04-reflexio/reflexio_feladat-1-VALIDATOR/reflexio_feladat/Program.cs
            //
            // Homework: not only the length should be checked but eg. if it contains @ symbol or not
            // To check here is a great example at this link: https://github.com/siposm/oktatas-hft-20211/blob/master/_archived/LA-04-reflexio/reflexio_feladat-1-VALIDATOR/reflexio_feladat/Program.cs
            // If 2 or more attributes are used this is the best way to validate them.

            // 2. RÉSZ
            // Ellenőrzés: kérjük le a Student típusokat és írjuk ki az email címüket.
            // Check: get the Student types and write out their emails

            Console.WriteLine("\n-----------------\n");
            Console.WriteLine("STUDENT TYPES: " + countStudentTypes);
            
            var q = from x in students
                    where x.GetType().Equals(typeof(Student))
                    select x;
            
            q.ToList().ForEach( x => Console.WriteLine((x as Student).Email));

            #endregion
        }
    }
}
