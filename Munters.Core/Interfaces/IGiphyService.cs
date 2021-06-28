using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Munters.Core.Models;

namespace Munters.Core.Interfaces
{
    public interface IGiphyService
    {
        Task<Result> Fetch(Uri uri);      
    }
}
