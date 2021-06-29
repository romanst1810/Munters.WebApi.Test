using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Munters.Core.Interfaces;
using Munters.Core.Models;
using Munters.Test.Interfaces;

namespace Munters.Test.Services
{
    public class GiphySearchService : IGiphySearchService
    {
        private IGiphyWebService _giphyWebService;
        private IMemoryCache _cache;

        public GiphySearchService(IGiphyWebService giphyWebService, IMemoryCache memoryCache)
        {
            this._giphyWebService = giphyWebService;
            this._cache = memoryCache;
        }
        public Task<GiphySearchResult> Fetch()
        {
            TrendingParameter trendingParameter = new TrendingParameter()
            {
                Format = "",
                Limit = 25,
                Rating = Rating.G
            };
            return _giphyWebService.Fetch(trendingParameter);
        }

        public async Task<GiphySearchResult> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                throw new ArgumentNullException(nameof(searchText));
            string searchValue = searchText.Trim();
            GiphySearchResult result = new GiphySearchResult();
            SearchParameter searchParameter = new SearchParameter
            {
                Query = searchValue
            };
            bool cacheExists = _cache.TryGetValue(searchValue, out result);
            if (cacheExists)
                return result;

            result = await _giphyWebService.Search(searchParameter);
            _cache.Set(searchValue, result, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

            return result;
        }
    }
}
