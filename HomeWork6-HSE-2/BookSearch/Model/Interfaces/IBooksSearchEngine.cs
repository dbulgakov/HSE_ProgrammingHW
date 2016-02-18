using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BookSearch.Model.Interfaces
{
    interface IBooksSearchEngine
    {
        Task<ObservableCollection<Book>> SearchBooksAsync(string query);
    }
}
