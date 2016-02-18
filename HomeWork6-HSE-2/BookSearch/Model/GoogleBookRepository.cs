using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookSearch.Model.DTO.Responce;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

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

        public async void Search(string query)
        {
            _books.Clear();
            IBooksSearchEngine bSearchEngine = new GoogleBooksSearchEngine();
            var t = await bSearchEngine.SearchBooksAsync(query);
            foreach (var book in t)
            {
                _books.Add(book);
            }
        }
    }
}
