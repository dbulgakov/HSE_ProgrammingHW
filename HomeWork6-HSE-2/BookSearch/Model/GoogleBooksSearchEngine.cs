using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using BookSearch.Model.DTO.Responce;
using BookSearch.Model.Interfaces;
using Newtonsoft.Json;

namespace BookSearch.Model
{
    class GoogleBooksSearchEngine : IBooksSearchEngine
    {
        private const string GBUrl = "https://www.googleapis.com/books/v1/volumes?q=";

        public async Task<ObservableCollection<Book>> SearchBooksAsync(string query)
        {
            var responseString = await MakeSearchRequestAsync(query);
            return ParseResponseAsync(responseString);
        }

        private async Task<string> MakeSearchRequestAsync(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = GBUrl + query + "&maxResults=40"; // not ok to do so
                var response = await client.GetAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private ObservableCollection<Book> ParseResponseAsync(string responseString)
        {
            var responseData = JsonConvert.DeserializeObjectAsync<ResponseData>(responseString).Result;
            var oCollection = ConvertResponseBook(responseData);
            return oCollection;
        }

        private ObservableCollection<Book> ConvertResponseBook(ResponseData responseBooks)
        {
            ObservableCollection<Book> oCollection = new ObservableCollection<Book>();
            foreach (var book in responseBooks.ResponseBooks)
            {
                oCollection.Add(new Book
                {
                    Author = book.VolumeInfo.Authors == null ? "n/a" :  string.Join(", ", book.VolumeInfo.Authors.ToArray()),
                    Title = book.VolumeInfo.Title,
                    SubTitle = book.VolumeInfo.Subtitle ?? "n/a",
                    PublishDate = string.IsNullOrEmpty(book.VolumeInfo.PublishDate) ? "n/a" : book.VolumeInfo.PublishDate.Substring(0, 4),
                    Language = book.VolumeInfo.Language,
                    Thumbnail = book.VolumeInfo.ImageLinks == null ? null : book.VolumeInfo.ImageLinks.Thumbnail,
                    SmallThumbnail = book.VolumeInfo.ImageLinks == null ? null : book.VolumeInfo.ImageLinks.SmallThumbnail,
                    WebReaderLink = book.AccessInfo == null ? null : book.AccessInfo.WebReaderLink
                });
            }
            return oCollection;
        }
    }
}
