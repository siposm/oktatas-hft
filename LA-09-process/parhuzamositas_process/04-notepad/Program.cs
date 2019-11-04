using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_notepad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = new string[]{
                "cars.sql",
                "people.json",
                "treeworkers.xml"
            };

            Process[] procs = new Process[files.Length];

            for (int i = 0; i < procs.Length; i++)
            {
                procs[i] = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        //FileName = @"C:\Program Files\Notepad++\notepad++.exe",
                        FileName = "Notepad++.exe",
                        Arguments = files[i]
                    }
                };
                procs[i].Start();
            }
        }
    }
}
