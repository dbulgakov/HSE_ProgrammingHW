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
using StudentRating.Classes.RatingCalculators;
using StudentRating.Classes.Domain;


namespace StudentRating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository _repository;
        private IRatingCalculator _calculator;

        public MainWindow()
        {
            InitializeComponent();
            _repository = new TestRepository();
            _calculator = new HSE_RatingCalculator();
            _repository.GradesChanged += RefreshGrid;
            dataGridGrades.ItemsSource = _repository.Grades;
        }

        private void buttonRating_Click(object sender, RoutedEventArgs e)
        {
            textBlockRating.Text = String.Format("Your rating is = {0}", _calculator.CalculateRating(_repository.Grades));
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var g = new GradeWindow(ref _repository, sender);
            g.ShowDialog();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            var g = new GradeWindow(ref _repository, sender);
            g.ShowDialog();
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            while (dataGridGrades.SelectedItems.Count != 0)
            {
                _repository.RemoveGrade(g => g.Equals((Grade)dataGridGrades.SelectedItems[0]));
            }
        }

        private void RefreshGrid()
        {
            dataGridGrades.Items.Refresh();
        }
    }
}
