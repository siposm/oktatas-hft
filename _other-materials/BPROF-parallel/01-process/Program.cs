using System.Diagnostics;

namespace _01_process
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region list running processes

            //foreach (var p in Process.GetProcesses().OrderBy(x => x.Id))
            //    Console.WriteLine(string.Format("#{0}\t {1}", p.Id, p.ProcessName));

            #endregion

            #region process urls

            string[] urls = new string[]
            {
                "https://www.linkedin.com/in/s%C3%A1muel-l%C3%A9r%C3%A1nt-028313a1",
                "https://www.linkedin.com/in/tam%C3%A1s-t%C3%B6r%C3%B6k-ab1437220/",
                "https://www.linkedin.com/in/p%C3%A9ter-pongor-57b657291/",
                "https://www.linkedin.com/in/szappanos-benedek-985537176/",
                "https://www.linkedin.com/in/levente-kiss/",
                "https://www.linkedin.com/in/sipos-m/",
                "https://www.linkedin.com/in/kovacskoviandras/",
            };

            for (int i = 0; i < urls.Length; i++) // i = 1000 ? 
            {
                // path can be short as 'chrome.exe', but if it doesn't work, write full path
                Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", urls[i]);

                // long format, but more detailed:
                //Process p = new Process();
                //p.StartInfo = new ProcessStartInfo();
                //p.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                //p.StartInfo.Arguments = urls[i];
                //p.Start();

                //System.Threading.Thread.Sleep(1000);
            }

            #endregion
        }
    }
}