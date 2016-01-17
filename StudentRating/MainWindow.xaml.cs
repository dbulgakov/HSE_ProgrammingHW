using System;
using System.Windows;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Domain;
using StudentRating.Classes.Factories;

namespace StudentRating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private IRepository _repository;
        private IRatingCalculator _calculator;

        public MainWindow()
        {
            var factory = new BasicFactory();
            InitializeComponent();
            _repository = factory.GetRepository(RepositoryType.FILEREPOSITORY);
            _calculator = factory.GetCalculator(CalculatorType.HSERATINGCALCULATOR);
            _repository.GradesChanged += RefreshGrid;
            _repository.IOExceptionOccured += IOExceptionAlert;
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

        private void IOExceptionAlert()
        {
            MessageBox.Show("Error while working with file occured", "Error!");
        }
    }
}
