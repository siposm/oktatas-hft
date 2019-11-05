using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_notepad
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo di = new DirectoryInfo("./files-to-check/");

            var files = di.GetFiles("*", SearchOption.AllDirectories)
                .OrderBy( x => x.Name )
                .Where( x =>
                        x.Name.Contains(".xml") ||
                        x.Name.Contains(".json") ||
                        x.Name.Contains(".cs") ||
                        x.Name.Contains(".sql")).ToArray();

            
            Process[] procs = new Process[files.Length];

            for (int i = 0; i < procs.Length; i++)
            {
                procs[i] = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        //FileName = @"C:\Program Files\Notepad++\notepad++.exe",
                        FileName = "Notepad++.exe",
                        Arguments = files[i].DirectoryName + @"\" +files[i].Name
                    }
                };
                procs[i].Start();
            }
        }
    }
}
