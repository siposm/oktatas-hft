using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08_async_await
{
    class Program
    {
        static void Main(string[] args)
        {
            // ! ! ! 
            //
            // Jelen félévben és tárgyban nem tárgyaljuk az async-await párost.
            //
            // Bővebben SzT szakirányon kerül elő majd.
            //
            // ! ! ! 
            // 
            // ... ettől függetlenül egy kis kód róla, ha valakit érdekel. :)

            Console.WriteLine("Started...");

            var w = new Worker();
            w.DoWork();

            while (!w.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }

            Console.WriteLine("Finished...");
            Console.ReadLine();
        }
    }


    class Worker
    {
        public bool IsComplete { get; private set; }

        public async void DoWork()
        {
            this.IsComplete = false;
            Console.WriteLine("\t... doing my work");
            await LongOperation();
            Console.WriteLine("\t... my work is done");
            IsComplete = true;
        }

        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
               Console.WriteLine("\t >> long operation is under progress...");
               Thread.Sleep(3000);
            });
        }
    }

    // A háttérben az async-await miatt a kódunk módosul és kiegészül egyéb részekkel ( ez olyan mint a getX/setX esetén a getMethodX / setMethodX ).
    // - async kulcsszó miatt a kód a fordításkor megváltozik (állapotgép)
}
