using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearch.Model
{
    interface IBooksSearchEngine
    {
        Task<ObservableCollection<Book>> SearchBooksAsync(string query);
    }
}
