using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public  ObservableCollection<Book> SearchBooks(string query)
        {
            var responseString = MakeSearchRequest(query);
            return ParseResponse(responseString);
        }

        private string MakeSearchRequest(string query)
        {
            HttpClient client = new HttpClient();
            var request = GBUrl + query + "&maxResults=40";
            var response = client.GetAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        private ObservableCollection<Book> ParseResponse(string responseString)
        {
            var responseData = JsonConvert.DeserializeObject<ResponseData>(responseString);
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
