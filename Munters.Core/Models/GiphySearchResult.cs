using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Munters.Core.Models.GiphyImage;

namespace Munters.Core.Models
{
    public class GiphySearchResult
    {
        [JsonProperty("data")]
        public Data[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
