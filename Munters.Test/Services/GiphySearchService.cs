using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Munters.Core.Interfaces;
using Munters.Core.Models;
using Munters.Test.Interfaces;

namespace Munters.Test.Services
{
    public class GiphySearchService : IGiphySearchService
    {
        private IGiphyWebService _giphyWebService;

        public GiphySearchService(IGiphyWebService giphyWebService)
        {
            this._giphyWebService = giphyWebService;
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

        public Task<GiphySearchResult> Search(string searchText)
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Query = searchText
            };
            return _giphyWebService.Search(searchParameter);
        }
    }
}
