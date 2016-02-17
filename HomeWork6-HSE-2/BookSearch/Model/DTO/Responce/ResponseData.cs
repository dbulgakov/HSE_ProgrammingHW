using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookSearch.Model.DTO.Responce
{
    class ResponseData
    {
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }
        [JsonProperty("items")]
        public List<ResponseBook> ResponseBooks { get; set; }
    }
}
