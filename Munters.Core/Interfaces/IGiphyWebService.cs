using System.Threading.Tasks;
using Munters.Core.Models;

namespace Munters.Core.Interfaces
{
    public interface IGiphyWebService
    {
        Task<GiphySearchResult> Search(SearchParameter searchParameter);
        Task<GiphySearchResult> Fetch(TrendingParameter trendingParameter);
    }
}
