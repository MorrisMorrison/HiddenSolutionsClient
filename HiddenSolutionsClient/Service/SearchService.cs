using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HiddenSolutionsClient.Model;
using Newtonsoft.Json;

namespace HiddenSolutionsClient.Service
{
    public class SearchService
    {
        public string LastSearchQuery { get; set; }
        
        public IList<SolutionModel> Result { get; set; }
        
        public HttpClient Client { get; set; }

        public SearchService(HttpClient p_client)
        {
            Client = p_client;
            p_client.BaseAddress = new Uri("http://localhost:5000/");
            
        }

        public async Task<IList<SolutionModel>> Search(string p_searchQuery)
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync($@"http://localhost:5000/api/search?searchQuery={p_searchQuery}");
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