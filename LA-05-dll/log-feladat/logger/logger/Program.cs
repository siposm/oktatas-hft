using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoggerTXT; // >> LoggerForTxt
using LoggerLibrary; // >> interface + student osztály

namespace logger
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerForTXT logger = new LoggerForTXT();
            logger.Log(new Student() { Name = "Gipsz Géza ___ " });

        }
    }
}
