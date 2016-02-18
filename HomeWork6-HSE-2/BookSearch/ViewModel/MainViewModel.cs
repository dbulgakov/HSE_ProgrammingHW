using System.Collections.Generic;
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

        public List<Book> Books 
        {
            get { return _bRepo.Books; }
        }


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
            MessageBox.Show("Hello!");
        }
    }
}