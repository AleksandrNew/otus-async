using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        private void LoadData_OnClick(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            using (StreamReader streamReader = new StreamReader(FileTextBox.Text))
            {
                while (!streamReader.EndOfStream)
                {
                    TextBox.AppendText((streamReader.ReadLine() ?? string.Empty) + Environment.NewLine);
                    Task.Delay(1000).Wait();
                }
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
