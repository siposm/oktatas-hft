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
                "users.nik.uni-obuda.hu",
                "index.hu",
                "google.com"
               };

            foreach (var h in hosts)
            {
                Process p = Process.Start(new ProcessStartInfo("ping", "-n 10 " + h)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });
                p.EnableRaisingEvents = true;
                p.Exited += P_Exited;
            }
            Console.ReadLine();
        }

        private static void P_Exited(object sender, EventArgs e)
        {
            Console.WriteLine((sender as Process).StandardOutput.ReadToEnd());
        }
    }
}
