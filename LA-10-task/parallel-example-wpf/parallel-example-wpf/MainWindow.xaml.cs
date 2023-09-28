using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace parallel_example_wpf
{
    public class Player
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int BirthYear { get; set; }
        public int Connections { get; set; }
        public int CompletedCredits { get; set; }
        public int ActiveSemesterCount { get; set; }
        public string Image { get; set; }
    }
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Download_v0(object sender, RoutedEventArgs e)
        {
            /*  
             * 
             * Dispatcher explanation:
             * without dispatcher thread problem occurs
             * src: https://stackoverflow.com/questions/9732709/the-calling-thread-cannot-access-this-object-because-a-different-thread-owns-it
             * 
             * */
            cts = new CancellationTokenSource(); // should be created here on each button click, see exception otherwise
            this.result.Content = "Downloading in progress...";

            await Task.Run(async () =>
            {
                WebClient wc = new WebClient();
                string playersString = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/db/players.json");
                var q = JsonConvert.DeserializeObject<List<Player>>(playersString);
                await Task.Delay(4000);

                if (cts.Token.IsCancellationRequested) // should be placed AFTER the long running task, not before
                    return;

                this.Dispatcher.Invoke(() =>
                {
                    this.result.Content = $"Finished downloading {q.Count} results.";
                });
            }, cts.Token);
        }

        private async void Download_v1(object sender, RoutedEventArgs e)
        {
            /*  
             *  
             *  cts.Token.IsCancellationRequested
             *  --> replaced by exception
             *  --> IsCancellationRequested works only if there is no continuation, because continuation checks for exception
             *  
             * */
            cts = new CancellationTokenSource();
            this.result.Content = "Downloading in progress...";

            Task t = Task.Run(async () =>
            {
                WebClient wc = new WebClient();
                string playersString = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/db/players.json");
                var q = JsonConvert.DeserializeObject<List<Player>>(playersString);
                await Task.Delay(4000);

                cts.Token.ThrowIfCancellationRequested();

                this.Dispatcher.Invoke(() =>
                {
                    this.result.Content = $"Finished downloading {q.Count} results.";
                });
            }, cts.Token).ContinueWith(t =>
            {
                MessageBox.Show("Download was cancelled!");
            }, TaskContinuationOptions.OnlyOnCanceled);

            // but what if we need to handle all cases separately? --> add multiple continuations
            // problems will occur depending on the result/status of the task

            await t.ContinueWith(t =>
            {
                MessageBox.Show("Download was cancelled!");
            }, TaskContinuationOptions.OnlyOnCanceled);

            await t.ContinueWith(t =>
            {
                MessageBox.Show("Problem happened!");
            }, TaskContinuationOptions.OnlyOnFaulted);

            await t.ContinueWith(t =>
            {
                MessageBox.Show("Download was successful!");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private async void Download_v2(object sender, RoutedEventArgs e)
        {
            /*
             * include the task in try block
             * --> if everything worked out fine, the internal task.run will be continued with written the continuation
             * --> if exception is raised (like during cancellation) it will be handled in the catch block
             * 
             * */
            cts = new CancellationTokenSource();
            this.result.Content = "Downloading in progress...";

            try
            {
                await Task.Run(async () =>
                {
                    WebClient wc = new WebClient();
                    string playersString = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/db/players.json");
                    var q = JsonConvert.DeserializeObject<List<Player>>(playersString);
                    await Task.Delay(4000);

                    cts.Token.ThrowIfCancellationRequested();

                    this.Dispatcher.Invoke(() =>
                    {
                        this.result.Content = $"Finished downloading {q.Count} results.";
                    });
                }, cts.Token).ContinueWith(c =>
                {
                    MessageBox.Show("Download finished successfully!");
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Download was cancelled!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some problem happened!");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            this.result.Content = "Downloading cancelled!";
        }
    }
}
