using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearch.Model
{
    public interface IBookRepository
    {
        ObservableCollection<Book> Books { get; }
        Task SearchAsync(string query);
    }
}
