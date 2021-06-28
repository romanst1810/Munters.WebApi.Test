﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Munters.Core.Interfaces;
using Munters.Core.Models;

namespace Munters.BL.Services
{
    public class GiphyService : IGiphyService
    {
        public async Task<Result> Fetch(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Result result = new Result(false, "");
                    var response = await httpClient.GetAsync(uri);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    result.IsSuccess = response.IsSuccessStatusCode;
                    result.ResultJson = responseContent;
                    return result;
                }
                catch (Exception ex)
                {
                    return new Result(false, ex.Message);
                }
            }
        }
    }
}
