using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_fileProcessor_main
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = new string[] {
                "file1.txt",
                "file2.txt",
                "file3.txt",
                "file4.txt"
            };

            string[] outputs = new string[] {
                "save_file1.txt",
                "save_file2.txt",
                "save_file3.txt",
                "save_file4.txt"
            };

            int[] delays = new int[] {
                1, 2, 3, 20
            };

            Process[] pArray = new Process[inputs.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                pArray[i] = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = @"D:\CODES\oktatas-whp-19201\LA-09-process\parhuzamositas_process\08-fileProcessor\bin\Debug\08-fileProcessor.exe",
                        Arguments = inputs[i] + " " + outputs[i] + " " + delays[i]
                    }
                };
                pArray[i].Start();
            }

        }
    }
}
