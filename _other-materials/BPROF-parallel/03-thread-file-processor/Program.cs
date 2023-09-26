namespace _03_thread_file_processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region INIT

            string[] inputs = new string[] {
                    "_files/file1.txt",
                    "_files/file2.txt",
                    "_files/file3.txt",
                    "_files/file4.txt"
                };

            string[] outputs = new string[] {
                    "_output/save_file1.txt",
                    "_output/save_file2.txt",
                    "_output/save_file3.txt",
                    "_output/save_file4.txt"
                };

            int[] delays = new int[] { // * 1000 ==> seconds
                    1,
                    1,
                    1,
                    6
                };

            #endregion


            Thread[] threads = new Thread[inputs.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(DataProcessor.Process);
                threads[i].Start(new DataTransfer()
                {
                    OpenFile = inputs[i],
                    SaveAs = outputs[i],
                    TimeDelay = delays[i]
                });
            }

            // sync point
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            // by this point all the needed output files are created
            DataProcessor.CollectData(outputs);
        }
    }
}