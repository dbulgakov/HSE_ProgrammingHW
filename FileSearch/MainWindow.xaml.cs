using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FileSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchEngine engine;
        private const string DefaultProcessName = "notepad.exe";
        private const int DefaultMaxStringSize = 70;

        public MainWindow()
        {
            InitializeComponent();
            engine = new SearchEngine();
            engine.OnFileFound += ManageNewFoundFile;
        }


        private async void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxSearchResults.Items.Clear();
            engine.InitialDirectory = textBoxPath.Text;
            engine.Pattern = textBoxPattern.Text;
            
            try
            {
                await engine.GetFilesAsync();
                ChangeTextStatusBar(Properties.Resources.MainWindow_buttonSearch_Click_Search_process_finished_message);
            }
            catch (OperationCanceledException)
            {
                ChangeTextStatusBar(Properties.Resources.MainWindow_buttonSearch_Click_Search_process_canceled_message);
            }
        }

        private void ManageNewFoundFile(string pathToFile)
        {
            listBoxSearchResults.Dispatcher.Invoke(() => listBoxSearchResults.Items.Add(pathToFile));
            if (pathToFile.Length > DefaultMaxStringSize)
            {
                ChangeTextStatusBar(Properties.Resources.MainWindow_ManageNewFoundFile_Found_file_message + pathToFile.Substring(0, DefaultMaxStringSize) + Properties.Resources.MainWindow_ManageNewFoundFile_Too_long_string_symbols);
            }
            else
            {
                ChangeTextStatusBar(Properties.Resources.MainWindow_ManageNewFoundFile_Found_file_message + pathToFile);
            }
        }


        private void ChangeTextStatusBar(string text)
        {
            statusBarSearchStatus.Dispatcher.Invoke(() => statusBarSearchStatus.Text = text);
        }


        private void listBoxSearchResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBoxSearchResults.SelectedItem != null)
            {
                var fileName = listBoxSearchResults.SelectedItem.ToString();
                Process.Start(DefaultProcessName, listBoxSearchResults.SelectedItem.ToString());
                ChangeTextStatusBar(Properties.Resources.MainWindow_listBoxSearchResults_MouseDoubleClick_Open_file_message + fileName);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            engine.StopSearch();
        }
    }
}
