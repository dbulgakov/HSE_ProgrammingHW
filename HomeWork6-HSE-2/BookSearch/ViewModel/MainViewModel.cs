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
        private List<Book> _books;

        public List<Book> Books
        {
            get { return _books; }
        }


        public RelayCommand SearchCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                _books = new List<Book>()
                {
                    new Book
                    {
                        Title = "The Language of Flowers",
                        SubTitle =
                            "The Floral Offering: a Token of Affection and Esteem; Comprising the Language and Poetry of Flowers ...",
                        Author = "Henrietta Dumont",
                        Language = "EN",
                        PublishDate = 1852,
                        Thumbnail = null,
                        WebReaderLink = null
                    }
                };
            }
            else
            {
                
            }

            SearchCommand = new RelayCommand(Test);
        }

        private void Test()
        {
            MessageBox.Show("Hello!");
        }
    }
}