using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Munters.Core.Models;

namespace Munters.Test.Interfaces
{
    public interface IGiphySearchService
    {
        Task<GiphySearchResult> Search(string searchText);
        Task<GiphySearchResult> Fetch();
    }
}
