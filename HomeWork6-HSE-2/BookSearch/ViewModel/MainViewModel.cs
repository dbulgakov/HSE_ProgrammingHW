using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using BookSearch.Model;
using BookSearch.Model.Interfaces;
using BookSearch.Properties;
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
            SelectedBook = null;
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
                RaisePropertyChanged("Books");
            }

            catch (ArgumentException)
            {
                _dialogProvider.ShowMessage(Resources.MainViewModel_ExecuteSearch_WrongQuery, Resources.MainViewModel_ExecuteSearch_ErrorCaption);
            }

            catch (HttpRequestException)
            {
                _dialogProvider.ShowMessage(Resources.MainViewModel_ExecuteSearch_NoInternet, Resources.MainViewModel_ExecuteSearch_ErrorCaption);
            }

            catch (NullReferenceException)
            {
                _dialogProvider.ShowMessage(Resources.MainViewModel_ExecuteSearch_ParseError, Resources.MainViewModel_ExecuteSearch_ErrorCaption);
            }

            catch (Exception e)
            {
                _dialogProvider.ShowMessage(Resources.MainViewModel_ExecuteSearch_UnhandledError + e.Message, Resources.MainViewModel_ExecuteSearch_ErrorCaption);
            }

            ProgressRingIsActive = false;
        }

        public void OpenBookOnline()
        {
            System.Diagnostics.Process.Start(SelectedBook.WebReaderLink);
        }
    }
}