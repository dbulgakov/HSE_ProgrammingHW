using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookSearch.Model.DTO.Responce;
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
                    Author = book.VolumeInfo.Authors == null ? "" :  string.Join(", ", book.VolumeInfo.Authors.ToArray()),
                    Title = book.VolumeInfo.Title,
                    SubTitle = book.VolumeInfo.Subtitle,
                    PublishDate = book.VolumeInfo.PublishDate,
                    Language = book.VolumeInfo.Language,
                    Thumbnail = book.VolumeInfo.ImageLinks == null ? null : book.VolumeInfo.ImageLinks.Thumbnail,
                    WebReaderLink = book.VolumeInfo.AccessInfo == null ? null : book.VolumeInfo.AccessInfo.WebReaderLink
                });
            }
            return oCollection;
        }
    }
}
