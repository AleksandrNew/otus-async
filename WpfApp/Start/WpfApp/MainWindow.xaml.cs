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
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
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
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            await GetDataAsync(_cancellationToken);
        }

        private async Task GetDataAsync(CancellationToken cancellationToken)
        {
            using (StreamReader streamReader = new StreamReader(FileTextBox.Text))
            {
                while (!streamReader.EndOfStream)
                {
                    TextBox.AppendText((streamReader.ReadLine() ?? string.Empty) + Environment.NewLine);
                    await Task.Delay(1000);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }
                }
            }
        }


        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Token.Register(() => TextBox.AppendText("operation is cancelled"));
            _cancellationTokenSource.Cancel();
        }
    }
}
