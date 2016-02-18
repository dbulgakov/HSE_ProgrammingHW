using Newtonsoft.Json;

namespace BookSearch.Model.DTO.Responce
{
    class ImageLinks
    {
        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
