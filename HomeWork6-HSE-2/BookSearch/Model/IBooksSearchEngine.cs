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
        ObservableCollection<Book> SearchBooks(string query);
    }
}
