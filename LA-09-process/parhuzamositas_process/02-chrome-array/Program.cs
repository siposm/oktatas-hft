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
            string url = "http://users.nik.uni-obuda.hu/siposm/";
            Random r = new Random();
            Process[] procs = new Process[5];

            for (int i = 0; i < procs.Length; i++)
            {
                procs[i] = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                        Arguments = url
                    }
                };

                procs[i].Start();
            }
        }
    }
}
