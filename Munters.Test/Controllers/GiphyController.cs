using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Munters.Core.Models;
using Munters.Test.Interfaces;

namespace Munters.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiphyController : Controller
    {
        private IGiphySearchService _giphySearchService;
        public GiphyController(IGiphySearchService giphySearchService)
        {
            this._giphySearchService = giphySearchService;
        }
        
        [HttpGet]
        public Task<GiphySearchResult> Get()
        {
            var results = _giphySearchService.Fetch();
            return results;
        }
        [Route("search/{searchText}")]
        [HttpGet]
        public Task<GiphySearchResult> Search(string searchText)
        {
            var results = _giphySearchService.Search(searchText);
            return results;
        }
    }
}
