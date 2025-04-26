using FrontEnd.Helpers.Interfaces;

namespace FrontEnd.Helpers.Implementations
{
    public class ServiceHelper : IServiceHelper
    {
        public HttpClient HttpClient { get; set; }

        


        public ServiceHelper(HttpClient client, IConfiguration configuration)
        {
            string baseURL = configuration
                                .GetValue<string>("BackEnd:URL") ?? "";
                HttpClient = client;
            client.BaseAddress = new Uri(baseURL);

        }


        public HttpResponseMessage Delete(string url)
        {
            return HttpClient.DeleteAsync(url).Result;
        }

        public HttpResponseMessage GetResponseMessage(string url)
        {
            return HttpClient.GetAsync(url).Result;
        }

        public HttpResponseMessage Post(string url, object data)
        {
            return HttpClient.PostAsJsonAsync(url,data).Result;
        }

        public HttpResponseMessage Put(string url, object data)
        {
            return HttpClient.PutAsJsonAsync(url,data).Result;
        }
    }
}
