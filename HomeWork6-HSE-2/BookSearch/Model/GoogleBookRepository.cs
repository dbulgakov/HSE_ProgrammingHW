using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BookSearch.Model
{
    class GoogleBookRepository : ObservableObject, IBookRepository
    {
        private ObservableCollection<Book> _books;

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { Set(() => Books, ref _books, value); }
        }

        public GoogleBookRepository()
        {
            _books = new ObservableCollection<Book>()
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

        public void Add()
        {
            _books.Add(new Book
            {
                Title = "The Ldfssfge of Flowers",
                SubTitle =
                    "The Floral Offering: a Token of Affection and Esteem; Comprising the Language and Poetry of Flowers ...",
                Author = "Henrietta Dumont",
                Language = "EN",
                PublishDate = 1852,
                Thumbnail = null,
                WebReaderLink = null
            });
        }
    }
}
