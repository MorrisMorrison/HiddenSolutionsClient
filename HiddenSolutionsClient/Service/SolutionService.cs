using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HiddenSolutionsClient.Model;
using Newtonsoft.Json;

namespace HiddenSolutionsClient.Service
{
    public class SolutionService
    {
        
        public HttpClient Client { get; set; }
        
        public SolutionService(HttpClient p_client)
        {
            p_client.BaseAddress = new Uri("http://localhost:5000/");
            Client = p_client;
        }

        public async Task<bool> CreateSolution(SolutionModel p_model)
        {
            HttpResponseMessage response = await Client.PostAsync(new Uri("http://localhost:5000/api/solution"), new StringContent(JsonConvert.SerializeObject(p_model), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<SolutionModel> GetSolution(string p_id)
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync($@"http://localhost:5000/api/solution?id={p_id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                SolutionModel solutionModel = JsonConvert.DeserializeObject<SolutionModel>(await httpResponseMessage.Content.ReadAsStringAsync());
                return solutionModel;
            }

            return null;
        }
    }
}