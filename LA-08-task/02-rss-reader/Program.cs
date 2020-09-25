using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static void Download(object o)
        {
            int id = (int)o;
            xdocs[id] = XDocument.Load(urls[id]);

            foreach (var item in xdocs[id].Descendants("item"))
            {
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
        static void Main(string[] args)
        {
            Task[] tasks = new Task[DataProcessor.urls.Length];

            // start downloading
            for (int i = 0; i < tasks.Length; i++)
            {
                int _i = i; // OVT!!!
                tasks[i] = Task.Run( () => DataProcessor.Download(_i) );
                // tasks[i] = new Task(DataProcessor.Download, i);
                // tasks[i].Start();
            }

            // sync and write out
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                int id = 0;
                foreach (var item in DataProcessor.news)
                    Console.WriteLine($"[{id++}] : {item.Title}");

                Console.WriteLine("Select ID!");
                int choosen = new Random().Next(0,371);
                //int choosen = int.Parse(Console.ReadLine());
                /*
                    console readline-hoz linux / mac esetén a .vscode/launch.json-ban állítani kell!
                    src: https://github.com/OmniSharp/omnisharp-vscode/issues/2029
                    "In launch.json change the default value of console from internalTerminal to externalTerminal."
                */
                DataProcessor.Open(DataProcessor.news[choosen].URL);

            }).Wait();
        }
    }
}
