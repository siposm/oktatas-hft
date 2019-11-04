using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_process_array
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Process[] procs = new Process[5];

            for (int i = 0; i < procs.Length; i++)
            {
                procs[i] = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = @"D:\CODES\oktatas-whp-19201\LA-09-process\parhuzamositas_process\02-counter\bin\Debug\02-counter.exe",
                        Arguments = r.Next(10) + " " + r.Next(11,20),
                        RedirectStandardOutput = true, // próba: = false
                        UseShellExecute = false
                    }
                };

                procs[i].Start();
            }

            for (int i = 0; i < procs.Length; i++)
            {
                procs[i].WaitForExit();
                Console.WriteLine(procs[i].StandardOutput.ReadToEnd());
            }
        }
    }
}
