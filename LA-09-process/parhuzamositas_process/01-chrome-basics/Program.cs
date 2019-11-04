using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_chrome_basics
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://users.nik.uni-obuda.hu/siposm/";

            for (int i = 0; i < 5; i++) // i = 1000 ? 
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo();
                p.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                // filename = url esetén is az alapértelmezett program nyílik meg

                p.StartInfo.Arguments = url;
                p.Start();

                System.Threading.Thread.Sleep(1000);

            }


            foreach (var p in Process.GetProcesses().OrderBy(x => x.Id))
                Console.WriteLine(string.Format("#{0}\t {1}", p.Id, p.ProcessName));
        }
    }
}
