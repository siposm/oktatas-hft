namespace _05_task_file_processor_with_returns
{
    class DataProcessor
    {
        public static string[] Process(object o)
        {
            DataTransfer dt = o as DataTransfer;

            StreamReader sr = new StreamReader(dt.OpenFile);
            string full = sr.ReadToEnd();
            sr.Close();

            string saveStr = "";
            foreach (var item in full.Split("\r\n"))
                if (item.Contains("DATE:"))
                    saveStr += item + "*";

            System.Threading.Thread.Sleep(dt.TimeDelay * 1000);

            return saveStr.Substring(0, saveStr.Length - 1).Split('*');
        }

        public static void CollectData(string[] outputs)
        {
            // TODO based on the tasks' results
        }
    }
}