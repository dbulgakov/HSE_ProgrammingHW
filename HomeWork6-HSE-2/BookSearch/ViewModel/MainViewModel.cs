using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BookSearch.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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

        public Book SelectedBook { get; set; }
        


        public RelayCommand SearchCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IBookRepository bRepo, IDialogProvider dialogProvider)
        {
            _bRepo = bRepo;
            _dialogProvider = dialogProvider;
            SearchCommand = new RelayCommand(ExecuteSearch);
        }

        private void ExecuteSearch()
        {
            _bRepo.Search(InputQuery);
        }
    }
}