using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_fileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string open = args[0];
            string save = args[1];
            int timeDelay = int.Parse(args[2]);

            StreamReader sr = new StreamReader(open);

            string full = sr.ReadToEnd();

            string saveStr = "";
            foreach (var item in full.Split('\n'))
            {
                if(item.Contains("DATE:"))
                {
                    saveStr += item;
                }
            }

            System.Threading.Thread.Sleep(timeDelay * 1000);

            StreamWriter sw = new StreamWriter(save);
            sw.Write(saveStr);
            sw.Close();
        }
    }
}
