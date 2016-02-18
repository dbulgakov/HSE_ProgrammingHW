using Newtonsoft.Json;

namespace BookSearch.Model.DTO.Responce
{
    class ResponseBook
    {
        [JsonProperty("selfLink")]
        public string SelfLink { get; set; }
        [JsonProperty("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }
        [JsonProperty("accessInfo")]
        public AccessInfo AccessInfo { get; set; }
    }
}
