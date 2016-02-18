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
        public MainViewModel(IBookRepository bRepo)
        {
            _bRepo = bRepo;
            SearchCommand = new RelayCommand(Test);
        }

        private void Test()
        {
            _bRepo.Search(InputQuery);
        }
    }
}