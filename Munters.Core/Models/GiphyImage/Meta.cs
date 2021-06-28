using Newtonsoft.Json;

namespace Munters.Core.Models.GiphyImage
{

    public class Meta
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }

}
