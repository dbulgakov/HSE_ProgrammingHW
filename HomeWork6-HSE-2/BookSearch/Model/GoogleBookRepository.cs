using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BookSearch.Model.Interfaces;
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
            _books = new ObservableCollection<Book>();
        }

        public async Task SearchAsync(string query)
        {
            _books.Clear();
            IBooksSearchEngine bSearchEngine = new GoogleBooksSearchEngine();
            var t = await bSearchEngine.SearchBooksAsync(query);
            _books = t;
        }
    }
}
