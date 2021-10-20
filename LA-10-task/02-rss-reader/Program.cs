using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02_rss_reader
{
    class RSS
    {
        public string Title { get; set; }
        public string URL { get; set; }
    }

    class DataProcessor
    {
        public static string[] urls = {
            // "http://www.origo.hu/contentpartner/rss/sport/origo.rss",
            // "http://hvg.hu/rss/rss.hvg/hirek",
            // "https://sg.hu/plain/rss.xml",
            "https://www.hwsw.hu/xml/latest_news_rss.xml",
            "https://feeds.soundcloud.com/users/soundcloud:users:281745775/sounds.rss"
        };

        public static XDocument[] xdocs = new XDocument[urls.Length];

        public static List<RSS> news = new List<RSS>();

        public static void Open(string url)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo();
            p.StartInfo.FileName = "firefox"; // win: .exe is lehetséges, hogy kell mögé
            p.StartInfo.Arguments = url;
            p.Start();
            p.WaitForExit();
        }

        public static void Download(object o, CancellationToken CT)
        {
            int id = (int)o;
            xdocs[id] = XDocument.Load(urls[id]);

            // if (ct.IsCancellationRequested) break;
            CT.ThrowIfCancellationRequested();

            foreach (var item in xdocs[id].Descendants("item"))
            {
                Thread.Sleep(10);

                news.Add(new RSS()
                {
                    Title = item.Element("title").Value,
                    URL = item.Element("link").Value
                });
            }
        }
    }

    
    class Program
    {
        static CancellationTokenSource CTS = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Task[] tasks = new Task[DataProcessor.urls.Length];

            // start downloading
            for (int i = 0; i < tasks.Length; i++)
            {
                int _i = i; // OVT!!!
                tasks[i] = Task.Run( () => DataProcessor.Download(_i, CTS.Token), CTS.Token );
            }

            // sync and write out
            Task.WhenAll(tasks).ContinueWith( x =>
            {
                int id = 0; // != task ID
                foreach (var item in DataProcessor.news)
                    Console.WriteLine($"[{id++}] : {item.Title}");

                Console.WriteLine("Select ID!");
                int choosen = new Random().Next(0,371);
                Console.WriteLine("CHOOSEN: " + choosen);
                //int choosen = int.Parse(Console.ReadLine());
                /* console readline-hoz linux / mac esetén a .vscode/launch.json-ban állítani kell!
                    src: https://github.com/OmniSharp/omnisharp-vscode/issues/2029
                    "In launch.json change the default value of console from internalTerminal to externalTerminal." */
                DataProcessor.Open(DataProcessor.news[choosen].URL);

            }, TaskContinuationOptions.OnlyOnRanToCompletion); //.Wait >> blokkolná az egészet, nem tud továbbmenni lefele!!!
            
            Task.WhenAll(tasks).ContinueWith( x =>
            {
                Console.WriteLine("::: TASKS WERE CANCELED :::");
            }, TaskContinuationOptions.OnlyOnCanceled);



            
            Console.WriteLine("\n\n ::: PRESS ENTER TO CANCEL :::");
            Console.ReadLine();
            Console.WriteLine("\n\n ::: CANCELLING... :::");
            CTS.Cancel();
            Console.WriteLine("\n\n ::: ...CANCEL DONE :::");

            //Console.ReadLine(); // readline esetén a program még vár
                                // (blokkolva van a readline miatt) ezért az exception bekövetkezik
                                //
                                // readline berakása esetén
                                // utána nyomjunk a "folytatás" gombra és látni fogjuk hogy az OnlyOnCanceled rész is lefut
                                //
                                // itt most ez így jó nekünk, de lásd:
                                // https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-cancellation
        }
    }
}
