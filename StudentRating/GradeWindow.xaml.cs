using StudentRating.Classes.Domain;
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
using System.Windows.Shapes;
using StudentRating.Classes.Interfaces;

namespace StudentRating
{
    /// <summary>
    /// Interaction logic for GradeWindow.xaml
    /// </summary>
    public partial class GradeWindow : Window
    {
        private IRepository _repository;
        private Button _sender;
        private const string ErrorMessage = "Error!";
        private const string ArgumentNullExceptionMessage = "Please, chose the propriate course.";
        private const string ArgumentExceptionMessage = "Sorry, selected item already exists in grade list";
        private const string FormatExceptionMessage = "Plese, check your input, only numbers are accepted";
        private const string UnhandledErrorMessage = "Something went wrong";

        public GradeWindow(ref IRepository repository, object s)
        {
            InitializeComponent();
            comboBoxCourses.ItemsSource = repository.Courses;
            _repository = repository;
            _sender = (Button)s;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Grade grade = new Grade((Course)comboBoxCourses.SelectedValue, Convert.ToInt32(textBoxMark.Text));
                if (_sender.Name.Equals("buttonAdd"))
                {
                    _repository.AddGrade(grade);
                }
                else
                {
                    _repository.EditGrade(grade);
                }
                DialogResult = true;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(ArgumentNullExceptionMessage, ErrorMessage);
            }
            catch (FormatException)
            {
                MessageBox.Show(FormatExceptionMessage, ErrorMessage);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(ArgumentExceptionMessage, ErrorMessage);
            }
            catch (Exception)
            {
                MessageBox.Show(UnhandledErrorMessage, ErrorMessage);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
