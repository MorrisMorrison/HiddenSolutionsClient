using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HiddenSolutionsClient.Config;
using HiddenSolutionsClient.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HiddenSolutionsClient.Service
{
    public class SolutionService
    {
        public HttpClient Client { get; set; }
        private ApiConfig _apiConfig { get; set; }

        
        public SolutionService(IConfiguration p_configuration,HttpClient p_client)
        {
            _apiConfig = new ApiConfig(p_configuration);
            
            p_client.BaseAddress = new Uri(_apiConfig.BASEURL);
            Client = p_client;
        }

        public async Task<bool> CreateSolution(SolutionModel p_model)
        {
            HttpResponseMessage response = await Client.PostAsync(new Uri($"{_apiConfig.BASEURL}/api/solution"), new StringContent(JsonConvert.SerializeObject(p_model), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<SolutionModel> GetSolution(string p_id)
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync($@"{_apiConfig.BASEURL}/api/solution?id={p_id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                SolutionModel solutionModel = JsonConvert.DeserializeObject<SolutionModel>(await httpResponseMessage.Content.ReadAsStringAsync());
                return solutionModel;
            }

            return null;
        }

        public async Task<IList<SolutionModel>> GetAllSolutions()
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync($@"{_apiConfig.BASEURL}/api/solution");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                IList<SolutionModel> solutions = JsonConvert.DeserializeObject<IList<SolutionModel>>(await httpResponseMessage.Content.ReadAsStringAsync());
                return solutions;
            }

            return null;
        }
    }
}