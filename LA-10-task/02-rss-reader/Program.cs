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
            "http://hvg.hu/rss/rss.hvg/hirek",
            "https://sg.hu/plain/rss.xml",
            "https://www.hwsw.hu/xml/latest_news_rss.xml",
            "https://feeds.soundcloud.com/users/soundcloud:users:281745775/sounds.rss"
        };

        public static XDocument[] xdocs = new XDocument[urls.Length];

        public static List<RSS> news = new List<RSS>();

        public static void Open(string url)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo();
            p.StartInfo.FileName = "firefox"; // or Chrome or whatever, the .exe is maybe needed to place afterwards on Windows
            p.StartInfo.Arguments = url;
            p.Start();
            p.WaitForExit();
        }

        public static void Download(int index, CancellationToken CT)
        {
            Task.Delay(1000).Wait(); // in order to slow down a little bit the "processing" time

            //if (CT.IsCancellationRequested) return;
            CT.ThrowIfCancellationRequested();

            xdocs[index] = XDocument.Load(urls[index]);

            foreach (var item in xdocs[index].Descendants("item"))
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
        // The updated Main method is now considered an Async main, which allows for an asynchronous entry point into the executable./
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/cancel-an-async-task-or-a-list-of-tasks

        static void Main(string[] args) // !!!!!!!!!!!!!!!!!!!!!
        {
            CancellationTokenSource CTS = new CancellationTokenSource();

            Task[] tasks = new Task[DataProcessor.urls.Length];

            // start downloading
            for (int i = 0; i < tasks.Length; i++)
            {
                int _i = i; // OVT!!!
                tasks[i] = Task.Run(() => DataProcessor.Download(_i, CTS.Token), CTS.Token)
                    .ContinueWith(x =>
                        {
                            Console.WriteLine("Task was canceled.");

                        }, TaskContinuationOptions.OnlyOnCanceled);
            }

            // sync and write out
            Task.WhenAll(tasks).ContinueWith(x =>
            {
                int id = 0; // != task ID
                DataProcessor.news.ForEach(item => Console.WriteLine($"[{id++}] : {item.Title}"));

                int choosen = new Random().Next(0, DataProcessor.news.Count);
                Console.WriteLine("RANDOMLY SELECTED ID: " + choosen);

                // DataProcessor.Open(DataProcessor.news[choosen].URL);

            });





            Console.WriteLine("PRESS ANY KEY TO CANCEL"); Console.ReadLine();

            Console.WriteLine("CANCELING..."); CTS.Cancel(); Console.WriteLine("DONE");
            // NOTE:
            // IF we wait until the continuewith section is finished,
            // then we'll still see canceling, and still calling the Cancel method, but there is NOTHING to be cancelled


            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadLine();
        }
    }
}
