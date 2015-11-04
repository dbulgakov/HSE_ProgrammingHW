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
using StudentRating.Classes.Domain;

namespace StudentRating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        List<Grade> _grades;
        List<Course> _courses;

        private void InitTestData()
        {
            _courses = new List<Course>()
            {
                new Course("Programming", 4.15),
                new Course("Geometry and algebra", 2),
                new Course("Theoretical bases of informatics", 3.9)
            };
            
            _grades = new List<Grade>()
            _grades2 = new List<Grade>()
            {
                new Grade(_courses[0], 7),
                new Grade(_courses[1], 5),
                new Grade(_courses[2], 10)
            };
        }
        
        private double CalculateRating()
        {
            double rating = 0;
            foreach (var g in _grades)
                rating += g.Mark;
            return rating;
        }

        public MainWindow()
        {
            InitializeComponent();

            InitTestData();
            dataGridGrades.ItemsSource = _grades;
        }

        private void buttonRating_Click(object sender, RoutedEventArgs e)
        {
            textBlockRating.Text = String.Format("Your rating is = {0}", CalculateRating());
        }
    }
}
