using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Munters.BL.Tools;
using Munters.Core.Interfaces;
using Munters.Core.Models;
using Newtonsoft.Json;


namespace Munters.Test.Services
{
    public class GiphyWebService : IGiphyWebService
    {
        private const string BaseUrl = "http://api.giphy.com/";
        private const string BaseGif = "v1/gifs";
        private readonly string _authKey = "qW6lRapQJycpq5pOobUeZQPft8kKDr0c";

        private IGiphyService _giphyService;

        public GiphyWebService(IGiphyService giphyService)
        {
            this._giphyService = giphyService;
        }
       
        public async Task<GiphySearchResult> Search(SearchParameter searchParameter)
        {
            if (string.IsNullOrEmpty(searchParameter.Query))
            {
                throw new FormatException("Must set query in order to search.");
            }

            var nvc = new NameValueCollection();
            nvc.Add("q", searchParameter.Query);
            nvc.Add("limit", searchParameter.Limit.ToString());
            nvc.Add("offset", searchParameter.Offset.ToString());
            if (searchParameter.Rating != Rating.None)
                nvc.Add("rating", searchParameter.Rating.ToFriendlyString());
            if (!string.IsNullOrEmpty(searchParameter.Format))
                nvc.Add("fmt", searchParameter.Format);

            var result =
                await _giphyService.Fetch(new Uri($"{BaseUrl}{BaseGif}/search?api_key={_authKey}&{UriExtensions.ToQueryString(nvc)}"));
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get GIFs: {result.ResultJson}");
            }

            return JsonConvert.DeserializeObject<GiphySearchResult>(result.ResultJson);
        }

        public async Task<GiphySearchResult> Fetch(TrendingParameter trendingParameter)
        {
            var nvc = new NameValueCollection();
            nvc.Add("limit", trendingParameter.Limit.ToString());
            if (trendingParameter.Rating != Rating.None)
                nvc.Add("rating", trendingParameter.Rating.ToFriendlyString());
            if (!string.IsNullOrEmpty(trendingParameter.Format))
                nvc.Add("fmt", trendingParameter.Format);
            var result =
                await _giphyService.Fetch(new Uri($"{BaseUrl}{BaseGif}/trending?api_key={_authKey}&{UriExtensions.ToQueryString(nvc)}"));
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get GIF: {result.ResultJson}");
            }

            return JsonConvert.DeserializeObject<GiphySearchResult>(result.ResultJson);
        }
    }
}
