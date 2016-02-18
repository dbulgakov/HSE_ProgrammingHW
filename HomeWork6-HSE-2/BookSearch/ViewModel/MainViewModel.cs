using System.Collections.Generic;
using BookSearch.Model;
using GalaSoft.MvvmLight;

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
        

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            _books = new List<Book>()
            {
                new Book
                {
                    Title = "The Language of Flowers",
                    SubTitle =
                        "The Floral Offering: a Token of Affection and Esteem; Comprising the Language and Poetry of Flowers ...",
                    Authors = new List<string> {"Henrietta Dumont"},
                    Language = "EN",
                    PublishDate = 1852,
                    Thumbnail = null,
                    WebReaderLink = null
                }
            };
        }
    }
}