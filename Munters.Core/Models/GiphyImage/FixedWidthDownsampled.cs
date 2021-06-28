using Newtonsoft.Json;

namespace Munters.Core.Models.GiphyImage
{

    public class FixedWidthDownsampled
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

}
