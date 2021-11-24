using System;
using System.IO;
using System.Threading;

namespace _02_dataprocess
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
            DataTransfer dt = o as DataTransfer;

            StreamReader sr = new StreamReader(dt.OpenFile);
            string full = sr.ReadToEnd();
            sr.Close();

            string saveStr = "";
            foreach (var item in full.Split('\n'))
                if (item.Contains("DATE:"))
                    saveStr += item + "\n";

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
                full += sr.ReadToEnd() + "\n";
                sr.Close();
            }
            StreamWriter sw = new StreamWriter("./_output/final.txt");
            sw.Write(full);
            sw.Close();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            #region INIT

            string[] inputs = new string[] {
                    "./_files/file1.txt",
                    "./_files/file2.txt",
                    "./_files/file3.txt",
                    "./_files/file4.txt"
                };

            string[] outputs = new string[] {
                    "./_output/save_file1.txt",
                    "./_output/save_file2.txt",
                    "./_output/save_file3.txt",
                    "./_output/save_file4.txt"
                };

            int[] delays = new int[] { // * 1000 ==> seconds
                    1,
                    1,
                    1,
                    6
                };

            #endregion


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

            // sync point
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            // by this point all the needed output files are created
            DataProcessor.CollectData(outputs);
        }
    }
}
