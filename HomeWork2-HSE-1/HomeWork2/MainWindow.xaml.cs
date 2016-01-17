using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HomeWork2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Repository dataRepo = new Repository();

        public MainWindow()
        {   
            InitializeComponent();
            lvMatches.ItemsSource = dataRepo.MatchList;
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Все несохраненные данные будут удалены, продолжить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                dataRepo.Clean();
                lvMatches.ItemsSource = dataRepo.MatchList;
                tbStatus.Text = "Файл создан";
                cbMatches.IsEnabled = false;
            }
            
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            DialogProcessor dialogProcessor = new DialogProcessor();
            FileStream fStream = (FileStream)dialogProcessor.CreateOpenFileDialog();
            if (fStream != null)
            {
                if (dataRepo.ReadFromXml(fStream))
                {
                    tbStatus.Text = "Файл успешно открыт";
                    lvMatches.ItemsSource = dataRepo.MatchList;
                    if (dataRepo.MatchList.Count > 0)
                    {
                        cbMatches.SelectedIndex = -1;
                        cbMatches.IsEnabled = true;
                    }
                }
                else
                {
                    tbStatus.Text = "Ошибка открытия файла";
                    dataRepo.Clean();
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (dataRepo.WriteToXml())
            {
                tbStatus.Text = "Файл сохранен";
            }
            else
            {
                tbStatus.Text = "Ошибка сохранения файла";
                SaveAs_Click(sender, e);
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            DialogProcessor dialogProcessor = new DialogProcessor();
            FileStream fStream = (FileStream)dialogProcessor.CreateSaveAsDialog();
            if (fStream != null)
            {
                if (dataRepo.WriteToXml(fStream))
                {
                    tbStatus.Text = "Файл сохранен";
                }
                else
                {
                    tbStatus.Text = "Ошибка сохранения файла";
                }
            }
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutProgramWindow aboutProgramWindow = new AboutProgramWindow();
            aboutProgramWindow.ShowDialog();
        }

        private void AddMatch_Click(object sender, RoutedEventArgs e)
        {
            AddNewMatchWindow addNewMatchWindow = new AddNewMatchWindow(dataRepo.ReturnMaxId());
            bool? result = addNewMatchWindow.ShowDialog();
            if (result == true)
            {
                dataRepo.MatchList.Add(addNewMatchWindow.CreatedMatch);
                tbStatus.Text = "Добавлен элемент";
                if (dataRepo.MatchList.Count > 0)
                {
                    cbMatches.SelectedIndex = -1;
                    cbMatches.IsEnabled = true;
                }
            }
        }

        private void DelMatch_Click(object sender, RoutedEventArgs e)
        {
            if ((lvMatches.SelectedIndex < dataRepo.MatchList.Count) && (lvMatches.SelectedIndex != -1))
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    dataRepo.MatchList.RemoveAt(lvMatches.SelectedIndex);
                    tbStatus.Text = "Удален элемент";
                    if (dataRepo.MatchList.Count == 0)
                    {
                        cbMatches.IsEnabled = false;
                    }
                }
            }
            else
            {
                tbStatus.Text = "Нет элементов для удаления";
            }
        }

        private void cbMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindingList<Match> filteredMatchList = new BindingList<Match>();

            if (cbMatches.SelectedIndex == -1)
            {
                cbMatches.ItemsSource = dataRepo.MatchList;
            }
            else
            {
                if (cbMatches.SelectedIndex == 0)
                {
                    foreach (Match match in dataRepo.MatchList)
                    {
                        if (match is FootballMatch)
                        {
                            filteredMatchList.Add(match);
                        }
                    }
                }
                else if (cbMatches.SelectedIndex == 1)
                {
                    foreach (Match match in dataRepo.MatchList)
                    {
                        if (match is TennisMatch)
                        {
                            filteredMatchList.Add(match);
                        }
                    }
                }
                lvMatches.ItemsSource = filteredMatchList;
            }
        }
    }
}
