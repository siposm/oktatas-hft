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
        [CheckLength(MaxLength = 10)]
        public string Email { get; set; }

        public string NeptunID { get; set; }

        public int Credits { get; set; }
    }

    class BscStudent : Student
    {
        public int EnrollmentYear; // sima mező, nem tulajdonság

        private int ActiveSemesters_1; // priv. nem látszik
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

            // 0. RÉSZ
            // Hozzuk létre a szükséges attribútumot.
            // - CheckLength: int MaxLength tulajdonsággal állítható
            // Alkalmazzuk ezt az Email tulajdonságra Student-ben.

            // 1. RÉSZ
            // A Student típusok emailjeit ellenőrizzük le! (pl. a user beír valamit, és még mielőtt elmentenénk)
            // Reflexió segítségével vizsgáljuk meg a teljes tömböt, HA Student típusról van szó
            // akkor szűrjünk a megfelelő tulajdonságra és attribútum felhasználásával ellenőrizzük
            // annak helyességét.

            int countStudentTypes = 0;
            string newEmail = "lorem-ipsum-dolor-sit-amet@mail.com"; // első rész max 10 karakter lehet

            foreach (var studentObject in students)
            {
                //if(studentObject.GetType().Equals(typeof(Student)))
                if(studentObject is Student) // << rövidebben :)
                {
                    countStudentTypes++;

                    foreach (PropertyInfo prop in studentObject.GetType().GetProperties())
                    {
                        foreach (Attribute attr in prop.GetCustomAttributes())
                        {
                            CheckLength cl = attr as CheckLength;
                            if(prop.Name == "Email")
                            {
                                string firstPart = newEmail.Split('@')[0];
                                string secondPart = newEmail.Split('@')[1];
                                    
                                if(firstPart.Length <= cl.MaxLength) // email ok
                                { 
                                    (studentObject as Student).Email = newEmail;
                                }
                                else // email nem ok
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
            // link: https://gitlab.com/siposm/oktatas-hft-20211/-/blob/master/_ARCHIVED/LA-04-reflexio/reflexio_feladat-1-VALIDATOR/reflexio_feladat/Program.cs

            // 2. RÉSZ
            // Ellenőrzés: kérjük le a Student típusokat és írjuk ki az email címüket.

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
