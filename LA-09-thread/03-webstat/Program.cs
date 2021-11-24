using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03_webstat
{
    class Measurement
    {
        public string Url { get; set; }
        public int Byte { get; set; }
        public int MilliSec { get; set; }
        public double Speed { get { return Math.Round((double)Byte / MilliSec, 3); } }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Measurement[] T = new Measurement[] {
                new Measurement() { Url = "http://microsoft.com" },
                new Measurement() { Url = "http://bing.com" },
                new Measurement() { Url = "http://google.com" },
                new Measurement() { Url = "http://uni-obuda.hu" },
                new Measurement() { Url = "http://users.nik.uni-obuda.hu/siposm/" },
                new Measurement() { Url = "http://users.nik.uni-obuda.hu/prog3/" },
                new Measurement() { Url = "http://users.nik.uni-obuda.hu/gitstats/" },
                new Measurement() { Url = "http://users.nik.uni-obuda.hu/sztf2/" },
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
                WriteOutName(threads[i].Name);

            // sync
            for (int i = 0; i < T.Length; i++)
                threads[i].Join();

            // returned info
            Console.WriteLine("\n\n");
            foreach (var item in T.OrderBy(x => x.Speed))
                WriteOutMeasurement(item.Url, item.Speed);





            Action<string, string> openFileAsProcess = (filename, argument) =>
            {
                Process p = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = filename,
                        Arguments = argument
                    }
                };
                p.Start();
            };

            Action<Measurement[]> createXML = x =>
            {
                XDocument doc = new XDocument();
                doc.Add(new XElement("measurements"));
                foreach (var item in x.OrderBy(m => m.Speed))
                {
                    doc.Root.Add(new XElement("measurement",
                        new XElement("Url", item.Url),
                        new XElement("Byte", item.Byte),
                        new XElement("MilliSec", item.MilliSec),
                        new XElement("Speed", item.Speed)
                    ));
                }
                string filename = "output.xml";
                doc.Save(filename);
                //openFileAsProcess(@"C:\Program Files\Notepad++\notepad++.exe", filename);
                openFileAsProcess("code", filename);
            };

            createXML(T);

            Action<Measurement[]> createJSON = x =>
            {
                var json = JsonSerializer.Serialize(x);
                string filename = "output.json";
                File.WriteAllText(filename, json);
                //openFileAsProcess(@"C:\Program Files\Notepad++\notepad++.exe", filename);
                openFileAsProcess("code", filename);
                // to see output.json prettier https://jsonformatter.curiousconcept.com/
            };

            createJSON(T);

            /*
            
            HOMEWORK

                    update the code so that the threads handle the createjson and createxml methods
                    meaning that each thread after it finished the measurement
                    creates its own xml and json with the same name what the thread has
            
            */
        }

        static void Measure(object o)
        {
            Measurement e = o as Measurement;
            Stopwatch sw = new Stopwatch();
            int avgLen = 0;
            int avgTim = 0;
            int iterations = 10;

            for (int i = 0; i < iterations; i++)
            {
                sw.Start();
                avgLen += (new WebClient()).DownloadString(e.Url).Length;
                sw.Stop();
                avgTim += (int)sw.ElapsedMilliseconds;
                sw.Reset();

                Thread.Sleep(500); // DOS !!!
            }

            e.Byte = avgLen / iterations;
            e.MilliSec = avgTim / iterations;

        }

        static void WriteOutName(string input)
        {
            Console.WriteLine($"> Waiting for {input} test...");
            // Console.Write($"> Waiting for ");
            // Console.Write($"{input}");
            // Console.Write($" test...\n");
        }

        static void WriteOutMeasurement(string url, double speed)
        {
            Console.WriteLine($"> Measurement: \t {url} \t {speed} KB/s");
            // Console.WriteLine($"> Measurement: ");
            // Console.WriteLine($"\tURL: {url}");
            // Console.WriteLine($"\tSTAT: {speed} kB/s");
        }
    }
}
