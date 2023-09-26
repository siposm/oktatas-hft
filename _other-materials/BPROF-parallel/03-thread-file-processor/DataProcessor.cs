namespace _03_thread_file_processor
{
    class DataProcessor
    {
        public static void Process(object o)
        {
            DataTransfer dt = o as DataTransfer;

            StreamReader sr = new StreamReader(dt.OpenFile);
            string full = sr.ReadToEnd();
            sr.Close();

            string saveStr = "";
            foreach (var item in full.Split('\n'))
                if (item.Contains("DATE:"))
                    saveStr += item + "\n";

            System.Threading.Thread.Sleep(dt.TimeDelay * 1000);

            StreamWriter sw = new StreamWriter(dt.SaveAs);
            sw.Write(saveStr);
            sw.Close();
        }

        public static void CollectData(string[] outputs)
        {
            string full = "";
            for (int i = 0; i < outputs.Length; i++)
            {
                StreamReader sr = new StreamReader(outputs[i]);
                full += sr.ReadToEnd() + "\n";
                sr.Close();
            }
            StreamWriter sw = new StreamWriter("_output/final.txt");
            sw.Write(full);
            sw.Close();
        }
    }
}