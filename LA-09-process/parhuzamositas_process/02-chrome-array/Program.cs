using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_chrome_array
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
                        FileName = @"D:\CODES\oktatas-whp-19201\LA-09-process\parhuzamositas_process\Counter\bin\Debug\Counter.exe",
                        Arguments = r.Next(10, 20) + " " + r.Next(30, 40),
                        RedirectStandardOutput = true, // próba: = false
                        UseShellExecute = false
                    }
                };

                procs[i].Start();
            }

            for (int i = 0; i < procs.Length; i++)
            {
                procs[i].WaitForExit(); // >> lefuttatáskor érdemes figyelni, hogy mikor éppen hogy alakul a process végrehajtásának ideje
                Console.WriteLine(procs[i].StandardOutput.ReadToEnd());
            }
        }
    }
}
