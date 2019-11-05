using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_event_binding
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hosts = new string[]
               {
                "www.gitlab.com",
                "www.index.hu",
                "www.google.com"
               };

            Process[] procs = new Process[hosts.Length];

            for (int i = 0; i < procs.Length; i++)
            {
                // 1 soros verzió
                //Process.Start("CMD.exe", "/c ping www.google.com -t");

                // Megjegyzés: van beépített Ping osztály...
                // using System.Net.NetworkInformation

                Process p = new Process();
                procs[i] = p;
                
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = $"/c ping {hosts[i]}";

                //p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;

                p.EnableRaisingEvents = true;
                p.Start();
                p.Exited += P_Exited; // (A) verzió: eseményen keresztül olvasom az adatokat
            }

            foreach (var item in procs) item.WaitForExit(); // sync

            // (B) verzió: elemenként kiolvasom az adatokat
            //foreach (var p in procs)
            //{
            //    Console.WriteLine(p.StandardOutput.ReadToEnd());
            //    Console.WriteLine("\n-------------------\n");
            //}

            // A/B verzió: egyszerre csak az egyik legyen használva, a másikat kommentezd ki
            // tehát vagy az eseményen keresztül olvasd a kimenetet (A)
            // vagy elemenként (B)
        }

        private static void P_Exited(object sender, EventArgs e)
        {
            Console.WriteLine((sender as Process).StandardOutput.ReadToEnd());
        }
    }
}
