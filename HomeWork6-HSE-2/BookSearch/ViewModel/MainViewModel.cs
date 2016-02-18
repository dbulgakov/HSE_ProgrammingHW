using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using BookSearch.Model;
using BookSearch.Model.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BookSearch.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IBookRepository _bRepo;
        private IDialogProvider _dialogProvider;

        public ObservableCollection<Book> Books 
        {
            get { return _bRepo.Books; }
        }

        public string InputQuery { get; set; }

        private bool _progressRindIsActive;

        public bool ProgressRingIsActive
        {
            get { return _progressRindIsActive; }
            set { Set(() => ProgressRingIsActive, ref _progressRindIsActive, value); }
        }


        private Book _selectedBook;

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                RaisePropertyChanged("SelectedBook");
            }
        }

        public RelayCommand SearchCommand { get; set; }

        public RelayCommand ReadOnlineCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IBookRepository bRepo, IDialogProvider dialogProvider)
        {
            _bRepo = bRepo;
            _dialogProvider = dialogProvider;
            SearchCommand = new RelayCommand(ExecuteSearch);
            ReadOnlineCommand = new RelayCommand(OpenBookOnline,
                () => SelectedBook != null && SelectedBook.WebReaderLink != null);
        }

        private async void ExecuteSearch()
        {
            ProgressRingIsActive = true;
            try
            {
                if (string.IsNullOrEmpty(InputQuery))
                {
                    throw new ArgumentException();
                }
                await _bRepo.SearchAsync(InputQuery);
            }
            catch (ArgumentException)
            {
                _dialogProvider.ShowMessage("Введите корректный поисковый запрос.");
            }
            catch (HttpRequestException)
            {
                _dialogProvider.ShowMessage("Проблемы с подключением к сети!");
            }
            catch (NullReferenceException)
            {
                _dialogProvider.ShowMessage("Не получилось разобрать ответ от сервера:C");
            }
            catch (Exception e)
            {
                _dialogProvider.ShowMessage("Что-то пошло не так." + e.Message);
            }

            ProgressRingIsActive = false;
        }

        public void OpenBookOnline()
        {
            MessageBox.Show("hello");
        }
    }
}