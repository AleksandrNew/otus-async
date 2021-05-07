using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Microsoft.Win32;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cancelTokenSource; 
        private  CancellationToken _token;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
                FileTextBox.Text = fileDialog.FileName;
        }

        private void Close_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void LoadData_OnClick(object sender, RoutedEventArgs e)
        {
            LoadData.IsEnabled = false;
            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;
            _cancelTokenSource.Token.Register(() => TextBox.AppendText("Cancellation Requested"));
            try
            {
                await GetDataAsync(_token);
            }
            catch (Exception exception)
            {

            }
            LoadData.IsEnabled = true;
        }

        private Task GetDataAsync(CancellationToken cancellationToken)
        {
            var path = FileTextBox.Text;

            var task = Task.Run(() =>
            {
                var lines = new List<string>();
                using StreamReader streamReader = new StreamReader(path);
                while (!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }

                return lines;
            }, cancellationToken);

            var result = task.ContinueWith( async t =>
            {
                foreach (var line in t.Result)
                {
                    Dispatcher.Invoke(() => { TextBox.AppendText(line + Environment.NewLine); });
                    await Task.Delay(1000);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    throw new Exception();
                }
            }, cancellationToken);

            result.ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    TextBox.AppendText("Done");
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            result.ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    TextBox.AppendText("Error");
                });
            }, TaskContinuationOptions.OnlyOnFaulted);

            return result;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            _cancelTokenSource.Cancel();
        }
    }
}
