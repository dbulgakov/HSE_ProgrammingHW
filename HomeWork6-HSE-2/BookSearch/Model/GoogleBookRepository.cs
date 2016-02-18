using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearch.Model
{
    class GoogleBookRepository : IBookRepository
    {
        private List<Book> _books;

        public List<Book> Books
        {
            get { return _books; }
        }

        public GoogleBookRepository()
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
    }
}
