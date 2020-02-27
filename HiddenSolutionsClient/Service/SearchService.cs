using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HiddenSolutionsClient.Config;
using HiddenSolutionsClient.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HiddenSolutionsClient.Service
{
    public class SearchService
    {
        public string LastSearchQuery { get; set; }
        
        public IList<SolutionModel> Result { get; set; }
        
        public HttpClient Client { get; set; }
        private ApiConfig _apiConfig { get; set; }

        public SearchService(IConfiguration p_configuration,HttpClient p_client)
        {
            _apiConfig = new ApiConfig(p_configuration);

            Client = p_client;
            p_client.BaseAddress = new Uri(_apiConfig.BASEURL);
        }

        public async Task<IList<SolutionModel>> Search(string p_searchQuery)
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync($@"{_apiConfig.BASEURL}/api/search?searchQuery={p_searchQuery}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                IList<SolutionModel> solutions = JsonConvert.DeserializeObject<IList<SolutionModel>>(await httpResponseMessage.Content.ReadAsStringAsync());

                LastSearchQuery = p_searchQuery;
                Result = solutions;
                return solutions;
            }

            return null;
        }
    }
}