using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_nslookup_example
{
    class Program
    {
        static void Main(string[] args)
        {
            string hosts = "index.hu, origo.hu, 444.hu, google.com, yahoo.com, bing.com, baidu.com, vk.com";
            List<string> hostlist = hosts.Split(',').Select(x => x.Trim()).ToList();
            List<Process> processes = new List<Process>();

            foreach (var h in hostlist)
            {
                processes.Add(Process.Start(new ProcessStartInfo("nslookup", h)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }));
            }

            foreach (var p in processes)
                p.WaitForExit();
            //de lehetne eventekkel is, ha szamolgatnank

            string searchFor = "Name:";
            foreach (var p in processes)
            {
                string res = p.StandardOutput.ReadToEnd();
                Console.WriteLine(res.Substring(res.IndexOf(searchFor)).Trim());
                //TODO: ha van sok idod, akkor szovegfeldolgozas es begyujteni az eredmenyeket pl dictionarybe
                //addressbol tobb is lehet egy host eseten: Dictionary<string, string[]>
            }
            Console.ReadLine();
        }
    }
}
