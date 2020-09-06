using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_tracert_example
{
    class Program
    {
        static void Main(string[] args)
        {
            string sor = "";
            List<Process> ls = new List<Process>();
            do
            {
                Console.Write("Kérek egy domaint (kilépéshez hagyd üresen): ");
                sor = Console.ReadLine();
                if (sor != "")
                {
                    Process p = new Process()
                    {
                        StartInfo = new ProcessStartInfo("tracert", "-w 1000 " + sor)
                        {
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };
                    p.EnableRaisingEvents = true;
                    p.Exited += P_Exited;
                    ls.Add(p);
                    p.Start();
                }
            } while (sor != "");

            foreach (Process p in ls)
            {
                if (!p.HasExited)
                {
                    Console.WriteLine("Várakozás {0} host eredményére", p.StartInfo.Arguments.Split(' ').Last());
                    p.WaitForExit();
                }
            }
            Console.WriteLine("Az összes folyamat véget ért!");

            Console.ReadLine();
        }

        private static void P_Exited(object sender, EventArgs e)
        {
            Console.WriteLine((sender as Process).StandardOutput.ReadToEnd());
        }
    }
}
