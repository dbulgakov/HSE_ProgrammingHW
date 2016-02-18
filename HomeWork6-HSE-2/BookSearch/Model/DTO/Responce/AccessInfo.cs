using Newtonsoft.Json;

namespace BookSearch.Model.DTO.Responce
{
    class AccessInfo
    {
        [JsonProperty("webReaderLink")]
        public string WebReaderLink { get; set; }
    }
}
