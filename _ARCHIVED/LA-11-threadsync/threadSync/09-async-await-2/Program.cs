using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// !!!
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Net;

namespace _09_async_await_2
{
    // Add reference: System.Drawing ... for GDI+ ... Bitmap, Color ... 
    // We are NOT using BitmapData (to make things SLOW)
    class Program
    {
        static void WaitForKey()
        {
            while (!Console.KeyAvailable)
            {
                Console.Write(".");
                Task.Delay(500).Wait();
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            List<string> images = new List<string>()
            { // Order is important
                "https://i.imgur.com/H31sFP8.jpg", // MEDIUM 800x
                "https://i.imgur.com/hSA5vIrg.jpg", // LARGE 1400x
                "https://i.imgur.com/5o7SBBs.jpg" //SMALL 500x
            };
            Transformer robot = new Transformer();
            robot.DeleteAll();

            List<Task<long>> tasks = new List<Task<long>>();
            for (int i = 0; i < images.Count; i++)
            {
                // take 1 - blocking solution
                // long time = robot.ExecuteBlocking(images[i], $"{temp}.jpg");
                // Console.WriteLine($"ROBOT done in {time} ms");

                // take 2 - with task
                // cant use i => outer variable trap !!!!!!
                int temp = i;
                Task<long> t = new Task<long>(() => robot.ExecuteBlocking(images[temp], $"{temp}.jpg"));
                t.Start();
                tasks.Add(t);
            }

            // take 3 - with async/await, if there is time
            /*
            for (int i = 0; i < images.Count; i++)
            {
                // We don't even need tasks here if the result is void ...
                Task<long> t2 = robot.ExecuteAsync(images[i], i + ".jpg");
                tasks.Add(t2);
            }
            */

            Task.WhenAll(tasks).ContinueWith(prevTasks =>
            {
                Console.WriteLine("ALL DONE...");
                foreach (long time in prevTasks.Result)
                {
                    Console.WriteLine($"ROBOT done in {time} ms");
                }
            });

            Console.WriteLine("LOOP DONE...");
            WaitForKey();
        }
    }
    class Transformer
    {
        public void DeleteAll()
        {
            var pictures = new DirectoryInfo(Environment.CurrentDirectory).GetFiles("*.jpg");
            foreach (var file in pictures) file.Delete();
        }
        void MakeGrayScale(string filename)
        {
            Bitmap bmp = new Bitmap(filename);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int grey = (c.R + c.G + c.B) / 3;
                    c = Color.FromArgb(grey, grey, grey);
                    bmp.SetPixel(x, y, c);
                }
            }
            bmp.Save("gray_" + filename);
        }

        public long ExecuteBlocking(string url, string filename)
        {
            Console.WriteLine($"{filename} STARTED...");
            // HttpRequest, WebClient, HttpClient
            Stopwatch stw = new Stopwatch();
            stw.Start();
            WebClient client = new WebClient();
            client.DownloadFile(url, filename);
            Console.WriteLine($"{filename} DOWNLOADED...");
            MakeGrayScale(filename);
            Console.WriteLine($"{filename} DONE...");
            stw.Stop();
            return stw.ElapsedMilliseconds;
        }

        // Only for take3 - if there is time
        public async Task<long> ExecuteAsync(string url, string filename)
        {
            Console.WriteLine($"{filename} STARTED...");
            // HttpRequest, WebClient, HttpClient
            Stopwatch stw = new Stopwatch();
            stw.Start();
            WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(url, filename);
            Console.WriteLine($"{filename} DOWNLOADED...");
            await Task.Run(() => MakeGrayScale(filename));
            Console.WriteLine($"{filename} DONE...");
            stw.Stop();
            return stw.ElapsedMilliseconds;
        }
    }
}
