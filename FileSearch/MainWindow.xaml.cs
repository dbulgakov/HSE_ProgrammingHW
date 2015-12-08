using System;
using System.Collections.Generic;
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


        public MainWindow()
        {
            InitializeComponent();
            engine = new SearchEngine();
            engine.OnFileFound += AddItemToListBox;
        }


        private async void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxSearchResults.Items.Clear();
            engine.InitialDirectory = textBoxPath.Text;
            engine.Pattern = textBoxPattern.Text;
            
            try
            {
                await engine.GetFiles();
            }
            catch
            {
                MessageBox.Show("hello");
            }
        }

        private void AddItemToListBox(string item)
        {
            listBoxSearchResults.Dispatcher.Invoke(() => listBoxSearchResults.Items.Add(item));
        }


        private void listBoxSearchResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            engine.StopSearch();
        }
    }
}
