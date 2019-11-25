using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_webstat
{
    class Result
    {
        public string Url { get; set; }
        public int Byte { get; set; }
        public int MilliSec { get; set; }
        public double Speed { get { return (double)Byte / MilliSec; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Result[] T = new Result[] {
                new Result() { Url = "http://microsoft.com" },
                new Result() { Url = "http://bing.com" },
                new Result() { Url = "http://google.com" },
                new Result() { Url = "http://uni-obuda.hu" },
                new Result() { Url = "http://users.nik.uni-obuda.hu/siposm/" },
                new Result() { Url = "http://users.nik.uni-obuda.hu/prog3/" },
                new Result() { Url = "http://users.nik.uni-obuda.hu/gitstats/" },
                new Result() { Url = "http://users.nik.uni-obuda.hu/sztf2/" },
            };


            Thread[] threads = new Thread[T.Length];
            for (int i = 0; i < T.Length; i++)
            {
                threads[i] = new Thread(Measure);
                threads[i].Name = T[i].Url.Replace("http://", "");
                threads[i].Start(T[i]);
            }

            // info 
            for (int i = 0; i < T.Length; i++)
                Console.WriteLine($"Waiting for {threads[i].Name} test...");

            // sync
            for (int i = 0; i < T.Length; i++)
                threads[i].Join();

            // returned info
            for (int i = 0; i < T.Length; i++)
                Console.WriteLine("\tRESULT:\t{0}: {1} kB/s", T[i].Url, T[i].Speed);
        }

        static void Measure(object o)
        {
            Result e = o as Result;
            //System.Net.WebClient wc = new System.Net.WebClient();
            for (int i = 0; i < 50; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                e.Byte += (new System.Net.WebClient()).DownloadString(e.Url).Length;
                sw.Stop();
                e.MilliSec += (int)sw.ElapsedMilliseconds;
                //Thread.Sleep(100);
            }
        }
    }
}
