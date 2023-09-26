namespace _05_task_file_processor_with_returns
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
                    5,
                    1,
                    6
                };

            #endregion


            Task<string[]>[] tasks = new Task<string[]>[inputs.Length];

            for (int i = 0; i < tasks.Length; i++)
            {
                int _i = i; // OVT !!!!
                tasks[i] = Task.Run<string[]>(() =>
                {
                    return DataProcessor.Process(new DataTransfer()
                    {
                        OpenFile = inputs[_i],
                        SaveAs = outputs[_i],
                        TimeDelay = delays[_i]
                    });
                }
                );
            }

            // sync point
            Task.WaitAll(tasks);

            Console.WriteLine("**RESULTS**");
            foreach (var task in tasks)
            {
                foreach (var result in task.Result)
                {
                    Console.WriteLine("--> " + result);
                }
            }

            // by this point all the needed results are ready to be written out to the final file
            // access them through the result property of each task
        }
    }
}