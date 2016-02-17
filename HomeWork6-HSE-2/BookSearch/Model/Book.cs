using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearch.Model
{
    class Book
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Language { get; set; }
        public int PublishDate { get; set; }
        public string WebReaderLink { get; set; }
        public string Thumbnail { get; set; }
    }
}
