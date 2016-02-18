using System.Collections.Generic;
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
