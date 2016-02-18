using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BookSearch.Model.Interfaces
{
    public interface IBookRepository
    {
        ObservableCollection<Book> Books { get; }
        Task SearchAsync(string query);
    }
}
