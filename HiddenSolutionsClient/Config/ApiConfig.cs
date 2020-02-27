using Microsoft.Extensions.Configuration;

namespace HiddenSolutionsClient.Config
{
    public class ApiConfig
    {
        private IConfiguration _configuration { get; set; }
        public string BASEURL { get; }

        public ApiConfig(IConfiguration p_configuration)
        {
            _configuration = p_configuration;
            BASEURL = _configuration["Api:BaseUrl"];
        }
    }
}