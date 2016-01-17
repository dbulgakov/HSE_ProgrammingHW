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

namespace HomeWork2
{
    /// <summary>
    /// Interaction logic for AddNewMatchWindow.xaml
    /// </summary>
    public partial class AddNewMatchWindow
    {
        int objectCounterInMainWindow = 0;
        public AddNewMatchWindow(int id)
        {
            objectCounterInMainWindow = id;
            InitializeComponent();
        }
        public Match CreatedMatch { get; set; }

        private void cbMatchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            tbxParticipant1.Clear();
            tbxParticipant2.Clear();

            if (cbMatchType.SelectedIndex == 0)
            {
                tbParticipant1.Text = "Имя первой команды";
                tbParticipant2.Text = "Имя второй команды";
            }
            else
            {
                tbParticipant1.Text = "Имя первого игрока";
                tbParticipant2.Text = "Имя второго игрока";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Сначала нужно заполнить все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Score matchScore = ParseMatchScoreMasked(mtbScore.Text);
                if (cbMatchType.SelectedIndex == 0)
                {
                    CreatedMatch = new FootballMatch(dpMatchDate.SelectedDate.Value, matchScore, objectCounterInMainWindow, tbxParticipant1.Text, tbxParticipant2.Text);
                }
                else
                {
                    CreatedMatch = new TennisMatch(dpMatchDate.SelectedDate.Value, matchScore, objectCounterInMainWindow, tbxParticipant1.Text, tbxParticipant2.Text);
                }
                DialogResult = true;
            }
        }

        private void tbxParticipant_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            List<char> lettersList = textBox.Text.ToList();
            List<char> checkedList = new List<Char>(lettersList);

            foreach (char letter in lettersList)
            {
                if (!Char.IsLetter(letter))
                {
                    checkedList.Remove(letter);
                }
            }
            textBox.Text = new string(checkedList.ToArray());
        }

        private bool CheckEmptyFields()
        {
            if (dpMatchDate.SelectedDate == null)
                return true;
            if (String.IsNullOrEmpty(tbxParticipant1.Text))
                return true;
            if (String.IsNullOrEmpty(tbxParticipant2.Text))
                return true;
            string[] tmpArray = mtbScore.Text.Split(':');
            foreach (string subStr in tmpArray)
            {
                if (!subStr.Any(c => char.IsDigit(c)))
                    return true;
            }
            return false;
        }

        private Score ParseMatchScoreMasked(String scoresString)
        {
            string[] playersScores = scoresString.Split(':');
            int firstPlayerScore = int.Parse(playersScores[0].Trim('_'));
            int secondPlayerScore = int.Parse(playersScores[1].Trim('_'));
            return new Score(firstPlayerScore, secondPlayerScore);
        }
    }
}
