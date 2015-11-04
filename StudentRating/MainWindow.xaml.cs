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
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Repositories;

namespace StudentRating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository repo;
        
        private double CalculateRating()
        {
            double rating = 0;
            foreach (var g in repo.Grades)
                rating += g.Mark;
            return rating;
        }

        public MainWindow()
        {
            InitializeComponent();
            repo = new TestRepository();
            dataGridGrades.ItemsSource = repo.Grades;
        }

        private void buttonRating_Click(object sender, RoutedEventArgs e)
        {
            textBlockRating.Text = String.Format("Your rating is = {0}", CalculateRating());
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
