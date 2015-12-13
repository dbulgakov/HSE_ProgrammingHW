using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace FileSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private SearchEngine engine;
        private const string DefaultProcessName = "notepad.exe";
        private const int DefaultMaxStringSize = 70;

        public MainWindow()
        {
            InitializeComponent();
            engine = new SearchEngine();
            engine.OnFileFound = ManageNewFoundFile;
            engine.OnErrorOcured += ChangeTextStatusBar;
            engine.OnFileProcessed += IncreaseProgressbarValue;
            engine.OnMaxFileNumberChanged += IncreaseMaxProgressbar;
        }


        private async void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxSearchResults.Items.Clear();
            buttonCancel.IsEnabled = true;
            InitializeNewSearch();
            engine.InitialDirectory = textBoxPath.Text;
            engine.Pattern = textBoxPattern.Text;
            buttonSearch.IsEnabled = false;
            try
            {
                ChangeTextStatusBar(Properties.Resources.MainWindow_buttonSearch_Click_Search_process_start_message);
                await engine.GetFilesAsync();
                ChangeTextStatusBar(Properties.Resources.MainWindow_buttonSearch_Click_Search_process_finished_message);
            }
            catch (OperationCanceledException)
            {
                InitializeNewSearch();
                ChangeTextStatusBar(Properties.Resources.MainWindow_buttonSearch_Click_Search_process_canceled_message);
            }
            finally
            {
                if (listBoxSearchResults.Items.IsEmpty)
                {
                    MessageBox.Show(Properties.Resources.MainWindow_buttonSearch_Click_No_files_found_message);
                }
                buttonSearch.IsEnabled = true;
                buttonCancel.IsEnabled = false;
                progressBarSearch.IsIndeterminate = false;
            }
        }


        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            engine.StopSearch();
            buttonCancel.IsEnabled = false;
            engine.OnFileFound = null;
            ChangeTextStatusBar(Properties.Resources.MainWindow_buttonCancel_Click_Cancelling_search_process_message);
            progressBarSearch.IsIndeterminate = true;
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

        private void IncreaseMaxProgressbar(long delta)
        {
            progressBarSearch.Dispatcher.Invoke(() => progressBarSearch.Maximum += delta);
        }

        private void IncreaseProgressbarValue()
        {
            progressBarSearch.Dispatcher.Invoke(() => progressBarSearch.Value += 1);
        }

        private void InitializeNewSearch()
        {
            engine.OnFileFound = ManageNewFoundFile;
            progressBarSearch.Value = 0;
            progressBarSearch.Maximum = 0.0001;
        }
    }
}
