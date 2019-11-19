using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_szoveges_allomany
{
    class DataTransfer
    {
        public string OpenFile { get; set; }
        public string SaveAs { get; set; }
        public int TimeDelay { get; set; }
    }

    class DataProcessor
    {
        public static void Process(object o)
        {
            DataTransfer dt = (o as DataTransfer);

            StreamReader sr = new StreamReader(dt.OpenFile);
            string full = sr.ReadToEnd();

            string saveStr = "";
            foreach (var item in full.Split('\n'))
                if (item.Contains("DATE:"))
                    saveStr += item;

            System.Threading.Thread.Sleep(dt.TimeDelay * 1000);

            StreamWriter sw = new StreamWriter(dt.SaveAs);
            sw.Write(saveStr);
            sw.Close();
        }

        public static void CollectData(string[] outputs)
        {
            string full = "";
            for (int i = 0; i < outputs.Length; i++)
            {
                StreamReader sr = new StreamReader(outputs[i]);
                full += sr.ReadToEnd();
                sr.Close();
            }
            StreamWriter sw = new StreamWriter("final.txt");
            sw.Write(full);
            sw.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = new string[] {
                "file1.txt",
                "file2.txt",
                "file3.txt",
                "file4.txt"
            };

            string[] outputs = new string[] {
                "save_file1.txt",
                "save_file2.txt",
                "save_file3.txt",
                "save_file4.txt"
            };

            int[] delays = new int[] {
                1,
                1,
                1,
                1
            };


            // -------------------------------------------------------


            Thread[] threads = new Thread[inputs.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(DataProcessor.Process);
                threads[i].Start(new DataTransfer()
                {
                    OpenFile = inputs[i],
                    SaveAs = outputs[i],
                    TimeDelay = delays[i]
                });
            }

            // szinkronizációs pont
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            // biztosan minden kimeneti fájl előállt már
            DataProcessor.CollectData(outputs);
        }
    }
}
