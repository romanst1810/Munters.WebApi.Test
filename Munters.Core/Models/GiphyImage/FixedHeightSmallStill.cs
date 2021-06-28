﻿using Newtonsoft.Json;

namespace Munters.Core.Models.GiphyImage
{

    public class FixedHeightSmallStill
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

}
