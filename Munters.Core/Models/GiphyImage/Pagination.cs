using Newtonsoft.Json;

namespace Munters.Core.Models.GiphyImage
{

    public class Pagination
    {

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }

}
