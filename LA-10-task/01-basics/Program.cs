using System;
using System.Threading;
using System.Threading.Tasks;

namespace LA_08_task
{
    class Computer
    {
        public string Brand { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region INTRO_TO_TASK

            Task<string> t1 = new Task<string>(() => 
            {
                Thread.Sleep(1000);
                return "apple";
            });

            t1.Start();

            Console.WriteLine("TASK 1 result: " + t1.Result);

            
            
            // ============================================



            Task<Computer> t2 = Task.Run(() => 
            {
                Thread.Sleep(1000);
                return new Computer(){ Brand = "Apple" };
            });

            t2.ContinueWith<int>( x =>
            {
                Console.WriteLine("[t2] task has finished running.");
                Console.WriteLine("received input: " + x.Result.Brand);
                return x.Id;
            }).ContinueWith( x =>
            {
                Console.WriteLine(x.Id);
            }); // esetleg .wait-tel meg lehet várni

            
            
            // ============================================

            // result esetén meg kell várni az eredményt, tehát blokkol (mint a wait)
            //t2.Wait();

            // az alsó rész megírása után komment ezt ki / be !!
            Console.WriteLine(t2.Result);


            // task indítási lehetőségek:
            //Task task1 = new Task(new Action(SomeMethodName));
            //Task task2 = new Task(delegate { SomeMethodName(); });
            //Task task3 = new Task(() => SomeMethodName());
            //Task task4 = new Task(() => { SomeMethodName(); });

            #endregion
            
            // ###########################################################################################

            #region EXAMPLE

            // 1. indítsunk task-okat amik a Count metódust kapják meg, majd a végén várjuk be őket
            //      a metódus random két érték között számoljon el egyesével és írja ki a konzolra az aktuális értéket
            // 2. a metódust cseréljük le delegáltra

            Action<object> counterAction = o => 
            {
                int id = (int)o;

                int min = r.Next(10);
                int max = r.Next(20,80);

                for (int i = min; i < max; i++)
                {
                    //Console.ForegroundColor = (ConsoleColor)id; //windows only!
                    Console.WriteLine($"\t [ {id} ] : " + i);
                }
            };

            Task[] tasks = new Task[10];

            for (int i = 0; i < tasks.Length; i++)
            {
                //tasks[i] = new Task(Count, i); // with method
                tasks[i] = new Task(counterAction, i); // with action delegate
                tasks[i].Start();
            }

            // sync point
            Task.WhenAll(tasks).ContinueWith( t => 
            {
                //Console.ResetColor(); // windows only!
                Console.WriteLine("\n~~~~~~~~~~~~~~~~\n");
                for (int i = 0; i < tasks.Length; i++)
                {
                    Console.WriteLine($"\t{i}. task finished.");
                }
                Console.WriteLine("\n~~~~~~~~~~~~~~~~\n");
            }).Wait();

            #endregion

        }

        static Random r = new Random();

        public static void Count(object o)
        {
            int id = (int)o;

            int min = r.Next(10);
            int max = r.Next(20,80);

            for (int i = min; i < max; i++)
            {
                //Console.ForegroundColor = (ConsoleColor)id; //windows only!
                Console.WriteLine($"\t [ {id} ] : " + i);
            }
        }
    }
}
